namespace Models;


public class Group
{
    public int GroupId { get; set; }
    public string? Name { get; set; }
    public int MaxStudent { get; set; }
    public string? CourseName {get; set;}
    public int CourseId { get; set; }
}