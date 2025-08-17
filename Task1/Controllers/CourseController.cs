using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tasks.BLL.Interfaces;
using Tasks.BLL.ViewModels;
using Tasks.DAL.Models;
using Tasks.DAL.Repositories.Interfaces;

namespace Task1.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IInstructorRepository _instructorRepo;

        public CourseController(ICourseService courseService, IInstructorRepository instructorRepo)
        {
            _courseService = courseService;
            _instructorRepo = instructorRepo;
        }


        public IActionResult Index()
        {
            var courses = _courseService.GetAllCourses();
            return View(courses);
        }

        public IActionResult Details(Guid id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null) return NotFound();
            return View(course);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var vm = new CreateCoursePageVM
            {
                Course = new CreateCourseVM(),
                Instructors = _instructorRepo.GetActiveInstructors()
                             .Select(i => new SelectListItem
                             {
                                 Value = i.Id.ToString(),
                                 Text = $"{i.FirstName} {i.LastName}"
                             }).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCoursePageVM model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                Console.WriteLine("Validation Errors:");
                foreach (var err in errors)
                {
                    Console.WriteLine(err);
                }


                return View(model);
            }


            _courseService.CreateCourse(model.Course);

            TempData["SuccessMessage"] = "Course created successfully.";
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(Guid id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null) return NotFound();

            return View(course); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourseVM model)
        {
            if (ModelState.IsValid)
            {
                var updated = _courseService.UpdateCourse(model);
                if (updated) return RedirectToAction(nameof(Index));

                return NotFound();
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null) return NotFound();
            return View(course);
        }
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
