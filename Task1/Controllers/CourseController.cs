using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task1.Data;
using Task1.Models;
using Task1.Models.ViewModel;

namespace Task1.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string category)
        {
            var filteredCourses = _context.Courses.ToList();

            var categories = _context.Courses
                .Select(c => c.Category)
                .Distinct()
                .ToList();

            if (!string.IsNullOrEmpty(category) &&
                Enum.TryParse<CourseCategory>(category, out var parsedCategory))
            {
                filteredCourses = filteredCourses
                    .Where(c => c.Category == parsedCategory)
                    .ToList();
            }

            ViewBag.Categories = new SelectList(categories);
            ViewBag.SelectedCategory = category;

            return View(filteredCourses);
        }

        public IActionResult Details(Guid id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();

            var vm = new CourseVM(
                 course.Name,
                 course.Description,
                 course.Category.ToString(),
                 course.StartDate,
                 course.EndDate,
                 course.Instructors.FirstOrDefault()?.Id ?? 0
             );

            return View(vm);
        }
        public IActionResult Create()
        {

            ViewBag.Categories = new SelectList(Enum.GetValues(typeof(CourseCategory)));
            return View();
        }


        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                course.Id = Guid.NewGuid(); 
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }


            ViewBag.Categories = new SelectList(Enum.GetValues(typeof(CourseCategory)));
            return View(course);
        }

    }
}
