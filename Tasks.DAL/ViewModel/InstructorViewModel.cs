using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tasks.DAL.Models;

namespace Tasks.DAL.ViewModel
{
    public class InstructorViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [MaxLength(500)]
        public string Bio { get; set; }

        [Required]
        public Specialization Specialization { get; set; }

        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Department { get; set; }

        public DateTime HireDate { get; set; }

        public List<CourseViewModel> Courses { get; set; } = new List<CourseViewModel>();
    }
}
