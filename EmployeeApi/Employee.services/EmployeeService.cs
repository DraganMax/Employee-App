using Employee.core;
using Employee.core.Services;
using Employee.data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.services
{
    public class EmployeeService : EntityService<EmployeeModel>, IEmployeeService
    { 
        public EmployeeService(IEmployeesDbContext employeesDbContext) : base(employeesDbContext)
        { }

        public async Task<bool> AddEmployee(EmployeeModel employee)
        {
           return await Task.FromResult(Create(employee));
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            return await Task.FromResult(Get());
        }
    }
}
