using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Task1.Models
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
        [MaxLength(100, ErrorMessage = "Course name cannot exceed 100 characters.")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "Course name should not contain numbers.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Course description is required.")]
        [MaxLength(500, ErrorMessage = "Course description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Course category is required.")]
        public CourseCategory Category { get; set; } 

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
    }
}
