using Employee.core;
using System.Data.Entity;

namespace Employee.data
{
    public interface IEmployeesDbContext
    {
        DbSet<T> Set<T>() where T : class;

        DbSet<EmployeeModel> Employees { get; set; }

        int SaveChanges();
    }
}
