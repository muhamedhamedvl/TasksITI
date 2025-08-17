using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tasks.DAL.Data;
using Tasks.DAL.Models;
using Tasks.DAL.Repositores.Interfaces;

namespace Tasks.DAL.Repositores
{
    public class CourseRepo : ICourseRepo
    {
        private readonly AppDbContext _context;

        public CourseRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses
                           .Include(c => c.Instructors)
                           .ToList();
        }

        public Course? GetCourseById(Guid id)
        {
            return _context.Courses
                           .FirstOrDefault(c => c.Id == id);
        }

        public Course? GetCourseWithInstructors(Guid courseId)
        {
            return _context.Courses
                           .Include(c => c.Instructors)
                           .FirstOrDefault(c => c.Id == courseId);
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
        }

        public void Delete(Guid id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
            else
            {
                throw new KeyNotFoundException($"Course with ID {id} not found.");
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
