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

    public void UpdateCourse(EditCourseVM model)
    {
        var course = _repo.GetById(model.Id);
        if (course == null) return;

        course.Name = model.Name;
        course.Description = model.Description;
        course.Category = model.Category;
        course.StartDate = model.StartDate;
        course.EndDate = model.EndDate;
        course.IsActive = model.IsActive;
        course.InstructorId = model.InstructorId;

        _repo.Update(course);
        _repo.Save();
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
        var course = _repo.GetById(id);
        if (course == null) return;
        _repo.Delete(course.Id); 
        _repo.Save();
    }
}
