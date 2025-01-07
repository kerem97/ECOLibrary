using AutoMapper;
using ECOLibrary.BusinessLayer.Services.LoanService;
using ECOLibrary.DataAccessLayer.Abstract;
using ECOLibrary.DTOs.Loan.Requests;
using ECOLibrary.DTOs.Loan.Responses;
using ECOLibrary.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOLibrary.BusinessLayer.Concrete
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public LoanService(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }
        public async Task ReturnLoanAsync(string loanId)
        {
            if (string.IsNullOrEmpty(loanId))
            {
                throw new ArgumentException("Loan ID boş olamaz.");
            }

            await _loanRepository.ReturnLoanAsync(loanId);
        }
        public async Task<List<ReturnedLoanListResponse>> GetReturnedLoansAsync()
        {
            var loans = await _loanRepository.GetReturnedLoansAsync();

            return loans.Select(loan => new ReturnedLoanListResponse
            {
                LoanId = loan.Id,
                BookName = loan.BookCopy.Book.Name,
                Barcode = loan.BookCopy.Barcode,
                EmployeeName = $"{loan.Employee.Name} {loan.Employee.Surname}",
                LoanDate = loan.LoanDate,
                ReturnDate = loan.ReturnDate.Value
            }).ToList();
        }

        public async Task<List<LoanListResponse>> GetActiveLoansAsync()
        {
            var loans = await _loanRepository.GetAllActiveLoansAsync();

            return loans.Select(loan => new LoanListResponse
            {
                LoanId = loan.Id,
                BookName = loan.BookCopy.Book.Name,
                Barcode = loan.BookCopy.Barcode,
                EmployeeName = $"{loan.Employee.Name} {loan.Employee.Surname}",
                LoanDate = loan.LoanDate
            }).ToList();
        }
        public async Task CreateLoanAsync(LoanCreateRequest request)
        {
            if (string.IsNullOrEmpty(request.Barcode))
            {
                throw new ArgumentException("Barkod bilgisi boş olamaz.");
            }

            if (string.IsNullOrEmpty(request.EmployeeId))
            {
                throw new ArgumentException("Çalışan bilgisi boş olamaz.");
            }

            await _loanRepository.CreateLoanAsync(request);
        }


        public async Task<List<LoanListResponse>> GetAllLoansAsync()
        {
            var loans = await _loanRepository.GetAllAsync();
            return _mapper.Map<List<LoanListResponse>>(loans);
        }

        public async Task<LoanByIdResponse> GetLoanByIdAsync(string id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);
            return _mapper.Map<LoanByIdResponse>(loan);
        }

        public async Task AddLoanAsync(LoanCreateRequest loanDto)
        {
            var loan = _mapper.Map<Loan>(loanDto);
            await _loanRepository.AddAsync(loan);
        }

        public async Task UpdateLoanAsync(LoanUpdateRequest loanDto)
        {
            var loan = _mapper.Map<Loan>(loanDto);
            await _loanRepository.UpdateAsync(loan);
        }

        public async Task DeleteLoanAsync(string id)
        {
            await _loanRepository.DeleteAsync(id);
        }
    }
}
