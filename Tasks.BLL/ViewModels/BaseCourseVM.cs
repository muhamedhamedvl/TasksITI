using System;
using System.ComponentModel.DataAnnotations;
using Tasks.DAL.Models;

namespace Tasks.BLL.ViewModels
{
    public class BaseCourseVM
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course description is required.")]
        [MaxLength(500, ErrorMessage = "Course description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public CourseCategory Category { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public int InstructorId { get; set; }
    }
}
