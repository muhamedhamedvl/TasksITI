using Microsoft.EntityFrameworkCore;
using Tasks.DAL.Data;
using Tasks.DAL.Models;
using Tasks.DAL.Repositories.Interfaces;

namespace Tasks.DAL.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext _context;

        public InstructorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Instructor> GetActiveInstructors()
        {
            return _context.Instructors
                .Where(i => i.IsActive)
                .Include(i => i.Courses)
                .ToList();
        }

        public Instructor? GetById(int id)
        {
            return _context.Instructors
                .Include(i => i.Courses)
                .FirstOrDefault(i => i.Id == id);
        }
    }
}
