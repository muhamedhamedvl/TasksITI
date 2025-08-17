using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tasks.DAL.Models
{
    public enum CourseCategory
    {
        Programming,
        Design,
        Marketing
    }

    public class Course
    {
        [Key]
        public Guid Id { get; set; }   

        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course description is required.")]
        [MaxLength(500, ErrorMessage = "Course description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course category is required.")]
        public CourseCategory Category { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; } = true;

        public List<Instructor>? Instructors { get; set; }
    }
}
