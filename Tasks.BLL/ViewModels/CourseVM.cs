using Tasks.DAL.Models;

namespace Tasks.BLL.ViewModels
{
    public class CourseVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CourseCategory Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public int InstructorId { get; set; }
        public string InstructorFullName { get; set; } = string.Empty; 
    }
}
