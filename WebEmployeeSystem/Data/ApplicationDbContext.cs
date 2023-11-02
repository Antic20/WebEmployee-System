using Microsoft.EntityFrameworkCore;
using System.Net;
using WebEmployeeSystem.Models;

namespace WebEmployeeSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1,
                    FirstName = "John" ,
                    LastName = "Tenehel" ,
                    Address = "103rd Ave",
                    NetSalary = 10000 ,
                    Position="GM",
                    Email = "john@email.com"
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Sarah",
                    LastName = "Picket",
                    Address = "101rd Ave",
                    NetSalary = 20000,
                    Position = "CEO",
                    Email = "sarah@email.com"
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Mark",
                    LastName = "Ronson",
                    Address = "104rd Ave",
                    NetSalary = 30000,
                    Position = "Director",
                    Email = "mark@email.com"
                }
                );
        }

    }
}
