using System;
using System.Collections.Generic;
using Tasks.DAL.ViewModel;

namespace Tasks.BLL.Services.InstructorServices
{
    public interface IInstructorService
    {
        IEnumerable<InstructorViewModel> GetAllInstructors();
        InstructorViewModel? GetInstructorById(int id);
        DetailsInstructorViewModel? GetDetails(int id);
        InstructorEditViewModel? GetInstructorToEdit(int id);
        void AddInstructor(CreateInstructorViewModel instructor);
        void UpdateInstructor(InstructorEditViewModel instructor);
        void DeleteInstructor(int id);
    }
}
