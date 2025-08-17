using Tasks.BLL.ViewModels;

namespace Tasks.BLL.Interfaces
{
    public interface IInstructorService
    {
        IEnumerable<InstructorVM> GetActiveInstructors();
        InstructorVM? GetInstructorById(int id);
    }
}
