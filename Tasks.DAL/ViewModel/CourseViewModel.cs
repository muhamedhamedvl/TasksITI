using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tasks.DAL.Models;

namespace Tasks.DAL.ViewModel
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }   

        [Required]
        [Remote(action: "CheckCourseName", controller: "Courses")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course description is required.")]
        [MaxLength(500, ErrorMessage = "Course description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course category is required.")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public List<InstructorViewModel> Instructors { get; set; } = new();
    }
}
