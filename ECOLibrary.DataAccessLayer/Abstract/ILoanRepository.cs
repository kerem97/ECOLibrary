using ECOLibrary.DTOs.Loan.Requests;
using ECOLibrary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DataAccessLayer.Abstract
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        Task CreateLoanAsync(LoanCreateRequest request);
        Task<List<Loan>> GetAllActiveLoansAsync();
        Task<List<Loan>> GetReturnedLoansAsync();
        Task ReturnLoanAsync(string loanId);
    }
}
