using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DTOs.Employee.Responses
{
    public class EmployeeListResponse
    {
        public List<EmployeeByIdResponse> Employees { get; set; }
    }
}
