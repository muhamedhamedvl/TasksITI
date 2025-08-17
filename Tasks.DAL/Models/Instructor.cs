using System;
using System.Collections.Generic;

namespace Tasks.DAL.Models
{
    public enum Specialization
    {
        SoftwareDevelopment,
        Marketing,
        Business,
        Design
    }

    public class Instructor
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

        public Specialization Specialization { get; set; }

        public bool IsActive { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public DateTime HireDate { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
