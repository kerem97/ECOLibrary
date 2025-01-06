using ECOLibrary.DTOs.Employee.Requests;
using ECOLibrary.DTOs.Employee.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.BusinessLayer.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<EmployeeListResponse>> GetAllEmployeesAsync();
        Task<EmployeeByIdResponse> GetEmployeeByIdAsync(string id);
        Task AddEmployeeAsync(EmployeeCreateRequest employeeDto);
        Task UpdateEmployeeAsync(EmployeeUpdateRequest employeeDto);
        Task DeleteEmployeeAsync(string id);
    }
}
