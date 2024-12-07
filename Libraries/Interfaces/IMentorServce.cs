using Models;
namespace Interface;

public interface IMentorService
{
    public bool CreateMentor(Mentor mentor);
    public bool UpdateMentor(Mentor mentor);
    public bool DeleteMentor(int id);
    public void DisplayMentors();
}