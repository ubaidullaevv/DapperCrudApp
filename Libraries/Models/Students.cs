namespace Models;



public class Student 
{
    public int StudentId { get; set; }
    public string? Fullname { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public int GroupId { get; set; }
    public int MentorId { get; set; }
}