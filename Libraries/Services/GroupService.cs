using Models;
using Interface;
using Npgsql;
using System.Data;
using Dapper;
using System.Security.Cryptography.X509Certificates;


public class GroupService : IGroupService
{
    public List<Group>? Groups { get; set; }
    public bool CreateGroup(Group group)
    {
        try{
        string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
        
        using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
         string insertCommand="insert into Groups(name,maxStudent,courseName,courseId) values (@Name,@MaxStudent,@CourseName,@CourseId)";
        var res=connection.Execute(insertCommand,group);
        return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public bool DeleteGroup(int id)
    {
        try{
        string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
        using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
        string deleteCommand=$"Delete from Groups where id=@GroupId";
        var res=connection.Execute(deleteCommand,new {GroupId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayGroups()
    {
        try{
         string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
         using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
         string readCommand=$"select * from Groups";
         var res=connection.Query<Group>(readCommand).ToList();
         foreach(Group g in Groups)
         {
            System.Console.WriteLine($@"""
            Name = {g.Name}
            Course Name = {g.CourseName}
            Max Students = {g.MaxStudent}
            Course Id = {g.CourseId}
            """);
         }
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
        }
    }

    public bool UpdateGroup(Group Group)
    {
        try{
         string conectionString=$"Server=Localhost; Port=5432; Database=DapperCrudDB; User Id=postgres; password=12345;";
          using NpgsqlConnection connection=new NpgsqlConnection(conectionString);
          string updateComand=$"Update Groups set groupId=@GroupId name=@Name, courseName=@CourseName, maxStudents=@MaxStudents,courseId=@CourseId";
          var res=connection.Execute(updateComand,Group);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}
