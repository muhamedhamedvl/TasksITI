using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tasks.DAL.ViewModel
{
    public class EditCourseViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course description is required.")]
        [StringLength(500, ErrorMessage = "Course description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a category.")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Instructor(s) are required.")]
        public IEnumerable<InstructorViewModel> Instructors { get; set; } = new List<InstructorViewModel>();

        [Range(1, 500, ErrorMessage = "Duration must be between 1 and 500 hours.")]
        public int DurationInHours { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
