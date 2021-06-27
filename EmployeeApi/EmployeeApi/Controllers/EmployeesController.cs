using AutoMapper;
using Employee.core;
using Employee.core.Services;
using EmployeeApi.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeApi.Controllers
{
    public class EmployeesController : ApiController
    {
        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/employees")]
        public async Task<IHttpActionResult> Get()
        {
            var employees = await _employeeService.GetEmployees();
            return Ok(employees.Select(e => _mapper.Map<EmployeeRequest>(e)).ToList());
        }

        [HttpPost]
        [Route("api/employee")]
        public async Task<IHttpActionResult> AddEmployee(EmployeeRequest employee)
        {
            if (IsEmptyFields(employee))
            {
                return BadRequest("Some of required fields are empty. Please fill all mandatory fields!");
            }

            var result = await _employeeService.AddEmployee(_mapper.Map<EmployeeModel>(employee));

            if (!result)
            {
                return Conflict();
            }

            return Created(string.Empty, employee);
        }

        private bool IsEmptyFields(EmployeeRequest employee)
        {
            return string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrEmpty(employee.LastName)
                || string.IsNullOrEmpty(employee.Ssn);
        }

        protected readonly IEmployeeService _employeeService;

        protected readonly IMapper _mapper;
    }
}
