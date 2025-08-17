using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.BLL.Interfaces;
using Tasks.BLL.ViewModels;
using Tasks.DAL.Models;
using Tasks.DAL.Repositories.Interfaces;

namespace Tasks.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IInstructorRepository _instructorRepo;

        public CourseService(ICourseRepository courseRepo, IInstructorRepository instructorRepo)
        {
            _courseRepo = courseRepo;
            _instructorRepo = instructorRepo;
        }

        public IEnumerable<CourseDetailsVM> GetAllCourses()
        {
            var courses = _courseRepo.GetAll();
            return courses.Select(c => new CourseDetailsVM
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Category = c.Category.ToString(),
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                IsActive = c.IsActive,
                InstructorId = c.InstructorId,
                InstructorFullName = c.Instructor != null ? $"{c.Instructor.FirstName} {c.Instructor.LastName}" : "N/A"
            }).ToList();
        }

        public CourseDetailsVM? GetCourseById(Guid id)
        {
            var c = _courseRepo.GetById(id);
            if (c == null) return null;
            return new CourseDetailsVM
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Category = c.Category.ToString(),
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                IsActive = c.IsActive,
                InstructorId = c.InstructorId,
                InstructorFullName = c.Instructor != null ? $"{c.Instructor.FirstName} {c.Instructor.LastName}" : "N/A"
            };
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
            _courseRepo.Add(course);
            _courseRepo.Save();
        }

        public void UpdateCourse(EditCourseVM model)
        {
            var course = _courseRepo.GetById(model.Id);
            if (course == null) throw new Exception("Course not found");

            course.Name = model.Name;
            course.Description = model.Description;
            course.Category = model.Category;
            course.StartDate = model.StartDate;
            course.EndDate = model.EndDate;
            course.IsActive = model.IsActive;
            course.InstructorId = model.InstructorId;

            _courseRepo.Update(course);
            _courseRepo.Save();
        }

        public void DeleteCourse(Guid id)
        {
            _courseRepo.Delete(id);
            _courseRepo.Save();
        }
    }
}
