using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class Employee : Entity
    {
        public string Position { get; set; }
        public string NationalId { get; set; }
        public Guid DepartmentId { get; set; }
        public string ImageUrl { get; set; }
        public Department Department { get; set; }
    }

    public class Department : Entity
    {
        public ICollection<Employee> Employees { get; set; }
    }
}