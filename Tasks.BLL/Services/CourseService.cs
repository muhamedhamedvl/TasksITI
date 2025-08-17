using Microsoft.EntityFrameworkCore;
using Tasks.BLL.ViewModels;
using Tasks.DAL.Models;
using Tasks.DAL.Repositories.Interfaces;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repo;

    public CourseService(ICourseRepository repo)
    {
        _repo = repo;
    }

    public void CreateCourse(CreateCourseVM model)
    {
        var course = new Course
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Description = model.Description,
            Category = model.Category,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            IsActive = model.IsActive,
            InstructorId = model.InstructorId
        };

        _repo.Add(course);
        _repo.Save();
    }

    public bool UpdateCourse(CourseVM vm)
    {
        var course = _repo.GetById(vm.Id);
        if (course == null) return false;

        course.Name = vm.Name;
        course.Description = vm.Description;
        course.Category = vm.Category;
        course.StartDate = vm.StartDate;
        course.EndDate = vm.EndDate;
        course.IsActive = vm.IsActive;
        course.Hours = vm.Hours;
        course.InstructorId = vm.InstructorId;

        _repo.Update(course);
        return true;
    }
    public CourseVM GetCourseById(Guid id)
    {
        var course = _repo.GetById(id);
        if (course == null) return null;

        return new CourseVM
        {
            Id = course.Id,
            Name = course.Name,
            Description = course.Description,
            Category = course.Category,
            StartDate = course.StartDate,
            EndDate = course.EndDate,
            IsActive = course.IsActive,
            InstructorId = course.InstructorId,
            InstructorFullName = $"{course.Instructor.FirstName} {course.Instructor.LastName}"
        };
    }

    public IEnumerable<CourseVM> GetAllCourses()
    {
        return _repo.GetAll().Select(course => new CourseVM
        {
            Id = course.Id,
            Name = course.Name,
            Description = course.Description,
            Category = course.Category,
            StartDate = course.StartDate,
            EndDate = course.EndDate,
            IsActive = course.IsActive,
            InstructorId = course.InstructorId,
            InstructorFullName = $"{course.Instructor.FirstName} {course.Instructor.LastName}"
        });
    }

    public void DeleteCourse(Guid id)
    {
        _repo.Delete(id);
        _repo.Save();
    }
}
