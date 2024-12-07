using Models;
using Interface;
using Npgsql;
using System.Data;
using Dapper;
using System.Security.Cryptography.X509Certificates;
namespace Service;


public class CourseServics : ICourseService
{
    public List<Course>? Courses { get; set; }
    public bool CreateCourse(Course course)
    {
        try{
        string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
        
        using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
         string insertCommand="insert into courses(name,description,createdAt) values (@Name,@Description,@CreatedAt)";
        var res=connection.Execute(insertCommand,course);
        return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public bool DeleteCourse(int id)
    {
        try{
        string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
        using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
        string deleteCommand=$"Delete from courses where id=@courseId";
        var res=connection.Execute(deleteCommand,new {courseId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayCourses()
    {
        try{
         string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
         using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
         string readCommand=$"select * from courses";
         var res=connection.Query<Course>(readCommand).ToList();
         foreach(Course c in Courses)
         {
            System.Console.WriteLine($@"""
            Name = {c.Name}
            Description = {c.Description}
            CreatedAt = {c.CreatedAt}
            """);
         }
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
        }
    }

    public bool UpdateCourse(Course course)
    {
        try{
         string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
          using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
          string updateComand=$"Update courses set courseId=@CourseId name=@Name, description=@Description, createdAt=@CreatedAt";
          var res=connection.Execute(updateComand,course);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}
