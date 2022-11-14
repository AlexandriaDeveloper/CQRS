using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contract;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        // private readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
            //  this._context = context;
        }

        public async Task<IReadOnlyList<Employee>> GetAllEmployeesAsync(bool includeDepartment)
        {
            List<Employee> allEmployees = new List<Employee>();
            allEmployees = includeDepartment ? await _context.Employees.Include(x => x.Department).ToListAsync() : await _context.Employees.ToListAsync();
            return allEmployees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id, bool includeDepartment)
        {
            var employee = new Employee();
            employee = includeDepartment ? await _context.Employees.Include(x => x.Department).FirstOrDefaultAsync() : await _context.Employees.FirstOrDefaultAsync();
            return employee;
        }
    }
}