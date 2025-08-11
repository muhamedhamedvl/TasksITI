using Microsoft.AspNetCore.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class CourseController : Controller
    {
        private static List<Course> courses = new List<Course>
        {
            new Course
            {
                Id = 1,
                Name = "C# Basics",
                Description = "Learn the fundamentals of C# programming.",
                Category = CourseCategory.Programming,
                StartDate = new DateTime(2025, 8, 15),
                EndDate = new DateTime(2025, 9, 15),
                IsActive = true
            },
            new Course
            {
                Id = 2,
                Name = "UI/UX Design",
                Description = "Design user friendly and attractive interfaces.",
                Category = CourseCategory.Design,
                StartDate = new DateTime(2025, 9, 1),
                EndDate = new DateTime(2025, 10, 1),
                IsActive = false
            },
            new Course
            {
                Id = 3,
                Name = "Digital Marketing",
                Description = "Learn how to promote products online effectively.",
                Category = CourseCategory.Marketing,
                StartDate = new DateTime(2025, 8, 20),
                EndDate = new DateTime(2025, 9, 20),
                IsActive = true
            }
        };
        public IActionResult Index()
        {
            return View(courses);
        }
    }
}
