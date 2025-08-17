using Tasks.BLL.ViewModels;

public interface ICourseService
{
    IEnumerable<CourseDetailsVM> GetAllCourses();
    CourseDetailsVM? GetCourseById(Guid id);
    void CreateCourse(CreateCourseVM model);
    void UpdateCourse(EditCourseVM model);
    void DeleteCourse(Guid id);
}