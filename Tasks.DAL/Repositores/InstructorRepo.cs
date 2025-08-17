using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.DAL.Data;
using Tasks.DAL.Models;
using Tasks.DAL.Repositores.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Tasks.DAL.Repositores
{
    public class InstructorRepo : IInstructorRepo
    {
        private readonly AppDbContext _context;

        public InstructorRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Instructor> GetAllInstructors()
        {
            return _context.Instructors.AsNoTracking().ToList();
        }

        public Instructor? GetInstructorById(int id)
        {
            return _context.Instructors.Find(id);
        }

        public void Add(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
        }
        public void Update(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
        }

        public void Delete(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
