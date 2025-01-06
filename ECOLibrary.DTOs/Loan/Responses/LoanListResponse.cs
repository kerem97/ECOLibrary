using ECOLibrary.DTOs.Employee.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DTOs.Loan.Responses
{
    public class LoanListResponse
    {
        public List<LoanByIdResponse> Loans { get; set; }
    }
}
