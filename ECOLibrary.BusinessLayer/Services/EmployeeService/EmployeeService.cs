using AutoMapper;
using ECOLibrary.BusinessLayer.Services.EmployeeService;
using ECOLibrary.DataAccessLayer.Abstract;
using ECOLibrary.DTOs.Employee.Requests;
using ECOLibrary.DTOs.Employee.Responses;
using ECOLibrary.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOLibrary.BusinessLayer.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeListResponse>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map<List<EmployeeListResponse>>(employees);
        }

        public async Task<EmployeeByIdResponse> GetEmployeeByIdAsync(string id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            return _mapper.Map<EmployeeByIdResponse>(employee);
        }

        public async Task AddEmployeeAsync(EmployeeCreateRequest employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(EmployeeUpdateRequest employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(string id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}
