using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contract;

namespace Persistence.Repositories
{
    public class UOW : IUOW
    {
        private readonly EmployeeContext _context;
        private IEmployeeRepository _employeeRepository;
        public IEmployeeRepository EmployeeRepository => _employeeRepository = _employeeRepository ?? new EmployeeRepository(_context);
        public UOW(EmployeeContext context)
        {
            this._context = context;

        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}