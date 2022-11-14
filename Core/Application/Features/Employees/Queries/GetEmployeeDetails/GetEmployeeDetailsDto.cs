using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string NationalId { get; set; }
        public Guid DpeartmentId { get; set; }
        public string ImageUrl { get; set; }

    }
}