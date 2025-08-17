using System.Collections.Generic;
using Tasks.DAL.Models;

namespace Tasks.BLL.ViewModels
{
    public class InstructorVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public Specialization Specialization { get; set; }
        public bool IsActive { get; set; }

        public List<string> Courses { get; set; } = new(); 
    }
}
