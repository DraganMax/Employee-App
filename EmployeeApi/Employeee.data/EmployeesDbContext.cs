using System;
using System.Data.Entity;
using Employee.core;
using Employee.data.Migrations;

namespace Employee.data
{
    public class EmployeesDbContext : DbContext, IEmployeesDbContext
    {

        public EmployeesDbContext() : base("EmployeesDbContext")
        {
            Database.Log = Console.WriteLine;
            Database.SetInitializer<EmployeesDbContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeesDbContext, Configuration>());
        }

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
