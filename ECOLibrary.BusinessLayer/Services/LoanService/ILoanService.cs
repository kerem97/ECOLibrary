﻿using ECOLibrary.DTOs.Loan.Requests;
using ECOLibrary.DTOs.Loan.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.BusinessLayer.Services.LoanService
{
    public interface ILoanService
    {
        Task<List<LoanListResponse>> GetAllLoansAsync();
        Task<List<LoanListResponse>> GetActiveLoansAsync();
        Task<List<ReturnedLoanListResponse>> GetReturnedLoansAsync();
        Task ReturnLoanAsync(string loanId);
        Task CreateLoanAsync(LoanCreateRequest request);
        Task<LoanByIdResponse> GetLoanByIdAsync(string id);
        Task AddLoanAsync(LoanCreateRequest loanDto);
        Task UpdateLoanAsync(LoanUpdateRequest loanDto);
        Task DeleteLoanAsync(string id);
    }
}
