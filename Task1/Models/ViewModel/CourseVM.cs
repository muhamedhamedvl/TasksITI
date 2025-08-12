using System.Xml.Linq;

namespace Task1.Models.ViewModel
{
    public record CourseVM(string Name ,string Description ,string Category ,DateTime StartDate ,DateTime EndDate , int InstructorId);
}
