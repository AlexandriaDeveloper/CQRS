using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contract
{
    public interface IUOW
    {
        IEmployeeRepository EmployeeRepository { get; }
        Task<int> SaveChangesAsync();
    }
}