using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.DAL.Models;

namespace Tasks.DAL.Repositores.Interfaces
{
    public interface IInstructorRepo
    {
         IEnumerable<Instructor> GetAllInstructors();
         Instructor? GetInstructorById(int id);
         void Add(Instructor instructor);
         void Update(Instructor instructor);
         void Delete(int id);
         void SaveChanges();
    }
}
