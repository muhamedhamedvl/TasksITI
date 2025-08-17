using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.DAL.ViewModel;

namespace Tasks.BLL.Services.CourseServices
{
    public interface ICourseService
    {
        IEnumerable<CourseListItemViewModel> GetAll();
        CourseViewModel? GetCourseById(Guid id);
        DetailsViewModel? GetDeatils(Guid id);

        void AddCourse(CreateCourseViewModel course);
        EditCourseViewModel? GetCourseToEdit(Guid id);
        void UpdateCourse(EditCourseViewModel course);

        void DeleteCourse(Guid id);
    }
}
