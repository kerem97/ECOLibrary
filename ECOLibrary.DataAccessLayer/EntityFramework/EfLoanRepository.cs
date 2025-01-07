using ECOLibrary.DataAccessLayer.Abstract;
using ECOLibrary.DataAccessLayer.Concrete;
using ECOLibrary.DataAccessLayer.Repository;
using ECOLibrary.DTOs.Loan.Requests;
using ECOLibrary.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ECOLibrary.DataAccessLayer.EntityFramework
{
    public class EfLoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        private readonly Context _context;

        public EfLoanRepository(Context context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Loan>> GetReturnedLoansAsync()
        {
            return await _context.Loans
                .Include(l => l.BookCopy) 
                .Include(l => l.BookCopy.Book) 
                .Include(l => l.Employee)
                .Where(l => l.ReturnDate != null) 
                .ToListAsync();
        }

        public async Task ReturnLoanAsync(string loanId)
        {
            var loan = await _context.Loans
                .Include(l => l.BookCopy)
                .FirstOrDefaultAsync(l => l.Id == loanId);
            if (loan == null)
            {
                throw new InvalidOperationException("Ödünç kaydı bulunamadı.");
            }
            if (loan.ReturnDate != null)
            {
                throw new InvalidOperationException("Bu kitap zaten iade edilmiş.");
            }
            loan.ReturnDate = DateTime.Now;
            loan.BookCopy.IsAvailable = true;
            _context.BookCopies.Update(loan.BookCopy);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Loan>> GetAllActiveLoansAsync()
        {
            return await _context.Loans
                .Include(l => l.BookCopy)
                .Include(l => l.BookCopy.Book)
                .Include(l => l.Employee)
                .Where(l => l.ReturnDate == null)
                .ToListAsync();
        }
        public async Task CreateLoanAsync(LoanCreateRequest request)
        {
            var bookCopy = await _context.BookCopies
                .FirstOrDefaultAsync(bc => bc.Barcode == request.Barcode);

            if (bookCopy == null)
            {
                throw new InvalidOperationException("Girilen barkoda sahip bir kitap kopyası bulunamadı.");
            }

            if (!bookCopy.IsAvailable)
            {
                throw new InvalidOperationException("Bu kitap şu anda uygun değil.");
            }

            var loan = new Loan
            {
                Id = Guid.NewGuid().ToString(),
                BookCopyId = bookCopy.Id,
                EmployeeId = request.EmployeeId,
                LoanDate = request.LoanDate
            };

            await _context.Loans.AddAsync(loan);

            bookCopy.IsAvailable = false;

            await _context.SaveChangesAsync();
        }


    }
}
