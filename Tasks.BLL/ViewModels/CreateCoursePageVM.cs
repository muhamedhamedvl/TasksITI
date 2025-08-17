using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Tasks.BLL.ViewModels
{
    public class CreateCoursePageVM
    {
        public CreateCourseVM Course { get; set; } = new CreateCourseVM();
        public List<SelectListItem> Instructors { get; set; } = new List<SelectListItem>();
    }
}
