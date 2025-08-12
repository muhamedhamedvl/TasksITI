namespace Task1.Models
{
    public enum Specialization
    {
        SoftwareDevelopment, 
        Marketing, 
        Business,
        Design
    }
    public class Instructor
    {
        public int Id { get; set; }
        public string FristName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Bio {  get; set; } = string.Empty;
        public Specialization specialization { get; set; }
        public bool IsActive { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

    }
}
