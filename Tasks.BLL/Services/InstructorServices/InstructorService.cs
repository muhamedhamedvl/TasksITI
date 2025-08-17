using System.Collections.Generic;
using System.Linq;
using Tasks.DAL.Models;
using Tasks.DAL.Repositores.Interfaces;
using Tasks.DAL.ViewModel;

namespace Tasks.BLL.Services.InstructorServices
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepo _instructorRepo;

        public InstructorService(IInstructorRepo instructorRepo)
        {
            _instructorRepo = instructorRepo;
        }

        public void AddInstructor(CreateInstructorViewModel instructor)
        {
            var newInstructor = new Instructor
            {
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Email = instructor.Email,
                PhoneNumber = instructor.PhoneNumber,
                HireDate = instructor.HireDate
            };

            _instructorRepo.Add(newInstructor);
            _instructorRepo.SaveChanges();
        }

        public void DeleteInstructor(int id)
        {
            _instructorRepo.Delete(id);
            _instructorRepo.SaveChanges();
        }

        public IEnumerable<InstructorViewModel> GetAllInstructors()
        {
            return _instructorRepo.GetAllInstructors()
                .Select(i => new InstructorViewModel
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    Email = i.Email,
                    PhoneNumber = i.PhoneNumber,
                });
        }

        public DetailsInstructorViewModel? GetDetails(int id)
        {
            var instructor = _instructorRepo.GetInstructorById(id);
            if (instructor == null) return null;

            return new DetailsInstructorViewModel
            {
                Id = instructor.Id,
                FullName = instructor.FirstName + " " + instructor.LastName,
                Email = instructor.Email,
                PhoneNumber = instructor.PhoneNumber,
                HireDate = instructor.HireDate
            };
        }

        public InstructorViewModel? GetInstructorById(int id)
        {
            var instructor = _instructorRepo.GetInstructorById(id);
            if (instructor == null) return null;

            return new InstructorViewModel
            {
                Id = instructor.Id,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                PhoneNumber = instructor.PhoneNumber,
                Email = instructor.Email,
            };
        }

        public InstructorEditViewModel? GetInstructorToEdit(int id)
        {
            var instructor = _instructorRepo.GetInstructorById(id);
            if (instructor == null) return null;

            return new InstructorEditViewModel
            {
                Id = instructor.Id,
                FirstName = instructor.FirstName,
                Email = instructor.Email,
                PhoneNumber = instructor.PhoneNumber,
                HireDate = instructor.HireDate
            };
        }

        public void UpdateInstructor(InstructorEditViewModel instructor)
        {
            var existingInstructor = _instructorRepo.GetInstructorById(instructor.Id);
            if (existingInstructor == null) return;

            existingInstructor.FirstName = instructor.FirstName;
            existingInstructor.LastName = instructor.LastName;
            existingInstructor.Email = instructor.Email;
            existingInstructor.PhoneNumber = instructor.PhoneNumber;
            existingInstructor.HireDate = instructor.HireDate;
            _instructorRepo.Update(existingInstructor);
            _instructorRepo.SaveChanges();
        }
    }
}
