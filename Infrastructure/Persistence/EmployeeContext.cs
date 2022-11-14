using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasMany(x => x.Employees).WithOne(x => x.Department).HasForeignKey(t => t.DepartmentId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = Guid.NewGuid(),
                Name = " تجربه "

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}