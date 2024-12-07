using Models;
namespace Interface;

public interface IStudentService
{
    public bool CreateStudent(Student student);
    public bool UpdateStudent(Student student);
    public bool DeleteStudent(int id);
    public void DisplayStudents();
}