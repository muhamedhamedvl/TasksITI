using Tasks.BLL.ViewModels;

public interface ICourseService
{
    void CreateCourse(CreateCourseVM model);
    CourseVM GetCourseById(Guid id);
    IEnumerable<CourseVM> GetAllCourses();
    void DeleteCourse(Guid id);
    bool UpdateCourse(CourseVM model);
}