using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.EntityLayer.Concrete
{
    public class Loan
    {
        public string Id { get; set; }
        public string BookCopyId { get; set; }
        public BookCopy BookCopy { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }

}
