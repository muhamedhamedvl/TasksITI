using Tasks.DAL.Models;

namespace Tasks.DAL.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course? GetById(Guid id);
        void Add(Course course);
        void Update(Course course);
        void Delete(Guid id);
        void Save();
    }
}