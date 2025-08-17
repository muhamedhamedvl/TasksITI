namespace Tasks.BLL.ViewModels
{
    public class CourseDetailsVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int InstructorId { get; set; }   
        public string InstructorFullName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
