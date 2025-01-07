using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DTOs.Loan.Requests
{
    public class LoanCreateRequest
    {
        public string EmployeeId { get; set; }
        public string Barcode { get; set; }
        public DateTime LoanDate { get; set; }
    }

}
