using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.DAL.Repositores.Interfaces;
using Tasks.DAL.ViewModel;
using Tasks.DAL.Models;

namespace Tasks.BLL.Services.CourseServices
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepo _courseRepo;

        public CourseService(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public IEnumerable<CourseListItemViewModel> GetAll()
        {
            return _courseRepo.GetAllCourses().Select(c => new CourseListItemViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Category = c.Category.ToString(),
                Description = c.Description,
                StartDate = c.StartDate,
                EndDate = c.EndDate
            }).ToList();
        }

        public CourseViewModel? GetCourseById(Guid id)
        {
            var course = _courseRepo.GetCourseById(id);
            if (course == null)
                return null;

            return new CourseViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Category = course.Category.ToString(),
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                IsActive = course.IsActive,
                Instructors = course.Instructors?.Select(i => new InstructorViewModel
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    Bio = i.Bio,
                    Specialization = i.Specialization,
                    IsActive = i.IsActive,
                    Email = i.Email,
                    PhoneNumber = i.PhoneNumber,
                    Department = i.Department,
                    HireDate = i.HireDate
                }).ToList() ?? new List<InstructorViewModel>()
            };
        }

        public DetailsViewModel? GetDeatils(Guid id)
        {
            var course = _courseRepo.GetCourseWithInstructors(id);
            if (course == null)
                return null;

            return new DetailsViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Category = course.Category,
                Instructor = string.Join(", ", course.Instructors?.Select(i => $"{i.FirstName} {i.LastName}") ?? Enumerable.Empty<string>()),
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                DurationInHours = (int)(course.EndDate - course.StartDate).TotalHours
            };
        }

        public void AddCourse(CreateCourseViewModel course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            var newCourse = new Course
            {
                Id = Guid.NewGuid(),
                Name = course.Name,
                Description = course.Description,
                Category = Enum.TryParse<CourseCategory>(course.Category, out var parsedCategory)
                            ? parsedCategory
                            : throw new ArgumentException("Invalid category", nameof(course.Category)),
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                IsActive = true
            };

            _courseRepo.Add(newCourse);
            _courseRepo.SaveChanges();
        }

        public EditCourseViewModel? GetCourseToEdit(Guid id)
        {
            var course = _courseRepo.GetCourseById(id);
            if (course == null)
                return null;

            return new EditCourseViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Category = course.Category.ToString(),
                StartDate = course.StartDate,
                EndDate = course.EndDate,

                DurationInHours = (int)Math.Max(0, (course.EndDate - course.StartDate).TotalHours),

                Instructors = course.Instructors?.Select(i => new InstructorViewModel
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    Bio = i.Bio,
                    Specialization = i.Specialization,
                    IsActive = i.IsActive,
                    Email = i.Email,
                    PhoneNumber = i.PhoneNumber,
                    Department = i.Department,
                    HireDate = i.HireDate
                }).ToList() ?? new List<InstructorViewModel>()
            };
        }

        public void UpdateCourse(EditCourseViewModel course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            var existingCourse = _courseRepo.GetCourseById(course.Id);
            if (existingCourse == null)
                throw new KeyNotFoundException($"Course with ID {course.Id} not found.");

            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;
            existingCourse.StartDate = course.StartDate;
            existingCourse.EndDate = course.EndDate;
            existingCourse.Category = Enum.TryParse<CourseCategory>(course.Category, out var parsedCategory)
                                      ? parsedCategory
                                      : existingCourse.Category;

            _courseRepo.Update(existingCourse);
            _courseRepo.SaveChanges();
        }

        public void DeleteCourse(Guid id)
        {
            var course = _courseRepo.GetCourseById(id);
            if (course == null)
                throw new KeyNotFoundException($"Course with ID {id} not found.");

            _courseRepo.Delete(id);
            _courseRepo.SaveChanges();
        }
    }
}
