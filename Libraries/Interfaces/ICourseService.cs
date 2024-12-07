using Models;
namespace Interface;

public interface ICourseService
{
    public bool CreateCourse(Course course);
    public bool UpdateCourse(Course course);
    public bool DeleteCourse(int id);
    public void DisplayCourses();
}