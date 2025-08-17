using System;
using System.Collections.Generic;
using Tasks.DAL.Models;

namespace Tasks.DAL.ViewModel
{
    public class DetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CourseCategory Category { get; set; }
        public string Instructor { get; set; } = string.Empty;
        public List<string> EnrolledStudents { get; set; } = new();
        public int DurationInHours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
