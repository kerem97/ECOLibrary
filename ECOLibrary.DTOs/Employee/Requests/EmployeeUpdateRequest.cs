using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DTOs.Employee.Requests
{
    public class EmployeeUpdateRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
