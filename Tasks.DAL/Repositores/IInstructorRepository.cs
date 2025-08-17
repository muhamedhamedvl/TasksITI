using Tasks.DAL.Models;

namespace Tasks.DAL.Repositories.Interfaces
{
    public interface IInstructorRepository
    {
        IEnumerable<Instructor> GetActiveInstructors();
        Instructor? GetById(int id);
    }
}
