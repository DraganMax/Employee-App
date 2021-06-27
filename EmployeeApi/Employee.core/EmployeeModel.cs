using Employee.core.Models;

namespace Employee.core
{
    public class EmployeeModel : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Ssn { get; set; }

        public string Phone { get; set; }
    }
}
