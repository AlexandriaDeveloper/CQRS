using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Contract
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IReadOnlyList<Employee>> GetAllEmployeesAsync(bool includeDepartment);
        Task<Employee> GetEmployeeByIdAsync(Guid id, bool includeDepartment);
    }
}