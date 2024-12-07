namespace Models;



public class Mentor
{
    public int MentorId { get; set; }
    public string? Fullname { get; set; }
    public int Age { get; set; }
    public string? Profession { get; set; }
    public int GroupId { get; set; }
    public int CourseID { get; set; }
}