using System;

namespace Tasks.BLL.ViewModels
{
    public class EditCourseVM : BaseCourseVM
    {
        public Guid Id { get; set; }
        public int Hours { get; set; }
    }
}
