using Microsoft.AspNetCore.Mvc;
using Tasks.BLL.Services.InstructorServices;
using Tasks.DAL.ViewModel;

namespace Tasks.PL.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public IActionResult Index()
        {
            var instructors = _instructorService.GetAllInstructors();
            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            var instructor = _instructorService.GetDetails(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateInstructorViewModel model)
        {
            if (ModelState.IsValid)
            {
                _instructorService.AddInstructor(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var instructor = _instructorService.GetInstructorToEdit(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InstructorEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _instructorService.UpdateInstructor(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var instructor = _instructorService.GetInstructorById(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _instructorService.DeleteInstructor(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
