using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tasks.DAL.Models;

namespace Tasks.BLL.ViewModels
{
    public class CreateCourseVM
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(1, 1000, ErrorMessage = "Hours must be greater than 0")]
        public int Hours { get; set; }

        [Required]
        [Display(Name = "Instructor")]
        public int InstructorId { get; set; }
        public CourseCategory Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }


    }
}
