using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.DAL.ViewModel
{
    public class CreateInstructorViewModel
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Enter a valid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Hire date is required.")]
        public DateTime HireDate { get; set; }
    }
}
