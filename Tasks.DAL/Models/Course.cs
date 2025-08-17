using Microsoft.AspNetCore.Mvc;
using System;
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
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CourseCategory Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}