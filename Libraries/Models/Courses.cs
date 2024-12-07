namespace Models;

public class Course
{
    public int CourseID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}