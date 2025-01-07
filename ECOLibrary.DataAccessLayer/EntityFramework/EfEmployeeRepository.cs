using ECOLibrary.DataAccessLayer.Abstract;
using ECOLibrary.DataAccessLayer.Concrete;
using ECOLibrary.DataAccessLayer.Repository;
using ECOLibrary.DTOs.Employee.Responses;
using ECOLibrary.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOLibrary.DataAccessLayer.EntityFramework
{
    public class EfEmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly Context _context;

        public EfEmployeeRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<EmployeeWithLoanCountResponse>> GetAllWithLoanCountAsync()
        {
            var employeesWithLoanCount = await _context.Employees
                .Select(e => new EmployeeWithLoanCountResponse
                {
                    Id = e.Id,
                    Name = e.Name,
                    Surname = e.Surname,
                    LoanCount = _context.Loans.Count(l => l.EmployeeId == e.Id),
                    Status = e.Status,
                })
                .AsNoTracking()
                .ToListAsync();

            return employeesWithLoanCount;
        }
    }
}
