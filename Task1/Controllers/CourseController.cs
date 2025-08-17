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

        // ===================== READ =====================
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

        // ===================== CREATE =====================
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
                model.Instructors = _instructorRepo.GetActiveInstructors()
                             .Select(i => new SelectListItem
                             {
                                 Value = i.Id.ToString(),
                                 Text = $"{i.FirstName} {i.LastName}"
                             }).ToList();
                return View(model);
            }

            _courseService.CreateCourse(model.Course);
            TempData["SuccessMessage"] = "Course created successfully.";
            return RedirectToAction(nameof(Index));
        }

        // ===================== UPDATE =====================
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null) return NotFound();

            var vm = new EditCoursePageVM
            {
                Course = new EditCourseVM
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    Category = Enum.Parse<CourseCategory>(course.Category),
                    StartDate = course.StartDate,
                    EndDate = course.EndDate,
                    IsActive = course.IsActive,
                    InstructorId = course.InstructorId
                },
                Instructors = _instructorRepo.GetActiveInstructors()
                    .Select(i => new SelectListItem
                    {
                        Value = i.Id.ToString(),
                        Text = $"{i.FirstName} {i.LastName}",
                        Selected = i.Id == course.InstructorId
                    }).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditCoursePageVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Instructors = _instructorRepo.GetActiveInstructors()
                    .Select(i => new SelectListItem
                    {
                        Value = i.Id.ToString(),
                        Text = $"{i.FirstName} {i.LastName}",
                        Selected = i.Id == model.Course.InstructorId
                    }).ToList();
                return View(model);
            }

            _courseService.UpdateCourse(model.Course);
            TempData["SuccessMessage"] = "Course updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        // ===================== DELETE =====================
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _courseService.DeleteCourse(id);
            TempData["SuccessMessage"] = "Course deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
