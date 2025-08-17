using System;
using System.Collections.Generic;
using Tasks.DAL.Models;

namespace Tasks.DAL.Repositores.Interfaces
{
    public interface ICourseRepo
    {
        IEnumerable<Course> GetAllCourses();
        Course? GetCourseById(Guid id);
        Course? GetCourseWithInstructors(Guid courseId);
        void Add(Course course);
        void Update(Course course);
        void Delete(Guid id);
        void SaveChanges();
    }
}
