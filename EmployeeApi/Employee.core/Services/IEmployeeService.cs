using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.core.Services
{
    public interface IEmployeeService
    {
        Task<bool> AddEmployee(EmployeeModel employee);

        Task<IEnumerable<EmployeeModel>> GetEmployees();
    }
}
