using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Employees.Queries.GetEmployeesList
{
    public class GetEmployeeListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }

    }
}