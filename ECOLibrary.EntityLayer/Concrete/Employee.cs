using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.EntityLayer.Concrete
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Status { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
