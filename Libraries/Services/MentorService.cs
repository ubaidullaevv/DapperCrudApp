using Models;
using Interface;
using Npgsql;
using System.Data;
using Dapper;
using System.Security.Cryptography.X509Certificates;


public class MentorService : IMentorService
{
    public List<Mentor>? Mentors { get; set; }
    public bool CreateMentor(Mentor mentor)
    {
        try{
        string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
        
        using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
         string insertCommand="insert into Mentors(fullname,age,profession,courseId,groupId) values (@Fullname,@Age,@Profession,@CourseId,@GroupId)";
        var res=connection.Execute(insertCommand,mentor);
        return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public bool DeleteMentor(int id)
    {
        try{
        string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
        using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
        string deleteCommand=$"Delete from Mentors where id=@MentorId";
        var res=connection.Execute(deleteCommand,new {MentorId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayMentors()
    {
        try{
         string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
         using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
         string readCommand=$"select * from Mentor";
         var res=connection.Query<Mentor>(readCommand).ToList();
         foreach(Mentor g in Mentors)
         {
            System.Console.WriteLine($@"""
            Name = {g.Fullname}
            Course Name = {g.Age}
            Max Students = {g.Profession}
            Student Id = {g.CourseID}
            Mentor Id = {g.GroupId}
            """);
         }
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
        }
    }

    public bool UpdateMentor(Mentor mentor)
    {
        try{
         string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
          using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
          string updateComand=$"Update Mentors set mentorId=@MentorId fullname=@Fullname,age=@Age,profession=@Profession,courseId=@CourseId,groupId=@GroupId";
          var res=connection.Execute(updateComand,mentor);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}
