using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DTOs.Employee.Responses
{
    public class EmployeeWithLoanCountResponse
    {
        public string Id { get; set; } 
        public string Name { get; set; } 
        public string Surname { get; set; } 
        public int LoanCount { get; set; } 
        public bool Status { get; set; } 
    }
}
