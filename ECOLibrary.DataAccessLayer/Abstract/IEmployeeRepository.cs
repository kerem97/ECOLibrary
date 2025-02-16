﻿using ECOLibrary.DTOs.Employee.Responses;
using ECOLibrary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DataAccessLayer.Abstract
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<List<EmployeeWithLoanCountResponse>> GetAllWithLoanCountAsync();
    }
}
