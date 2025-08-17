using Tasks.BLL.Interfaces;
using Tasks.BLL.ViewModels;
using Tasks.DAL.Repositories.Interfaces;

namespace Tasks.BLL.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepo;

        public InstructorService(IInstructorRepository instructorRepo)
        {
            _instructorRepo = instructorRepo;
        }

        public IEnumerable<InstructorVM> GetActiveInstructors()
        {
            var instructors = _instructorRepo.GetActiveInstructors();
            return instructors.Select(i => new InstructorVM
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Bio = i.Bio,
                Specialization = i.Specialization,
                IsActive = i.IsActive,
                Courses = i.Courses.Select(c => c.Name).ToList()
            });
        }

        public InstructorVM? GetInstructorById(int id)
        {
            var instructor = _instructorRepo.GetById(id);
            if (instructor == null) return null;

            return new InstructorVM
            {
                Id = instructor.Id,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Bio = instructor.Bio,
                Specialization = instructor.Specialization,
                IsActive = instructor.IsActive,
                Courses = instructor.Courses.Select(c => c.Name).ToList()
            };
        }
    }
}
