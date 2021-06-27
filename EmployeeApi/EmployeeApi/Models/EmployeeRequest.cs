using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Models
{
    public class EmployeeRequest : EntityModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Ssn { get; set; }

        public string Phone { get; set; }
    }
}