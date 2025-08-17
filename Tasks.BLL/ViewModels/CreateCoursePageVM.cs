using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Tasks.BLL.ViewModels
{
    public class CreateCoursePageVM
    {
        public CreateCourseVM Course { get; set; }   
        public IEnumerable<SelectListItem> Instructors { get; set; }
    }
}
