using Models;
using Interface;
using Npgsql;
using System.Data;
using Dapper;
using System.Security.Cryptography.X509Certificates;


public class StudentService : IStudentService
{
    public List<Student>? Students { get; set; }
    public bool CreateStudent(Student student)
    {
        try{
        string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
        
        using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
         string insertCommand="insert into Students(fullname,email,address,phone,groupId,mentorId) values (@Fullname,@Email,@Address,@Phone,@GroupId,@MentorId)";
        var res=connection.Execute(insertCommand,student);
        return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public bool DeleteStudent(int id)
    {
        try{
        string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
        using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
        string deleteCommand=$"Delete from Students where id=@StudentId";
        var res=connection.Execute(deleteCommand,new {StudentId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayStudents()
    {
        try{
         string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
         using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
         string readCommand=$"select * from Students";
         var res=connection.Query<Student>(readCommand).ToList();
         foreach(Student g in Students)
         {
            System.Console.WriteLine($@"""
            Name = {g.Fullname}
            Email = {g.Email}
            Address = {g.Address}
            Phone  = {g.Phone}
            Mentor Id = {g.MentorId}
            Group Id = {g.GroupId}
            """);
         }
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
        }
    }

    public bool UpdateStudent(Student Student)
    {
        try{
         string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
          using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
          string updateComand=$"Update Students set StudentId=@studentId fullname=@fullname,email=@email,address=@address,mentorId=@mentorId,groupId=@groupId";
          var res=connection.Execute(updateComand,Student);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}
