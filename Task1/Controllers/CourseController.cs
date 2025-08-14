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
            var categories = _context.Courses
                .Select(c => c.Category)
                .Distinct()
                .ToList();

            var filteredCourses = string.IsNullOrEmpty(category)
                ? _context.Courses.ToList()
                : _context.Courses
                    .Where(c => c.Category == (CourseCategory)Enum.Parse(typeof(CourseCategory), category))
                    .ToList();

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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (_context.Courses.Any(c => c.Name.ToLower() == course.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Course already exists.");
            }

            if (ModelState.IsValid)
            {
                course.Id = Guid.NewGuid();
                _context.Courses.Add(course);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Course created successfully!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(Enum.GetValues(typeof(CourseCategory)));
            return View(course);
        }


        public IActionResult Edit(Guid id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();

            ViewBag.Categories = new SelectList(Enum.GetValues(typeof(CourseCategory)), course.Category);
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, Course course)
        {
            if (id != course.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var existing = _context.Courses.FirstOrDefault(c => c.Id == id);
                if (existing == null)
                    return NotFound();

                existing.Name = course.Name;
                existing.Description = course.Description;
                existing.Category = course.Category;
                existing.StartDate = course.StartDate;
                existing.EndDate = course.EndDate;
                existing.Instructors = course.Instructors;

                _context.SaveChanges();
                TempData["SuccessMessage"] = "Course updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(Enum.GetValues(typeof(CourseCategory)), course.Category);
            return View(course);
        }
        public IActionResult Delete(Guid id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"Course '{course.Name}' deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

    }
}
