using System;
using System.ComponentModel.DataAnnotations;

namespace Tasks.DAL.ViewModel
{
    public class InstructorEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Department { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
}
