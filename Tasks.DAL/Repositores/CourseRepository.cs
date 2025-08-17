using Microsoft.EntityFrameworkCore;
using Tasks.DAL.Data;
using Tasks.DAL.Models;
using Tasks.DAL.Repositories.Interfaces;

namespace Tasks.DAL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context) { _context = context; }

        public IEnumerable<Course> GetAll() => _context.Courses.Include(c => c.Instructor).ToList();
        public Course? GetById(Guid id) => _context.Courses.Include(c => c.Instructor).FirstOrDefault(c => c.Id == id);
        public void Add(Course course) => _context.Courses.Add(course);
        public void Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var course = _context.Courses.Find(id);
            if (course != null) _context.Courses.Remove(course);
        }
        public void Save() => _context.SaveChanges();
    }
}
