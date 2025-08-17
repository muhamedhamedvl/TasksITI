using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Tasks.BLL.ViewModels
{
    public class EditCoursePageVM
    {
        public EditCourseVM Course { get; set; }
        public IEnumerable<SelectListItem> Instructors { get; set; }
    }
}
