using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DTOs.Loan.Requests
{
    public class LoanUpdateRequest
    {
        public string Id { get; set; }
        public DateTime? ReturnDate { get; set; }
    }

}
