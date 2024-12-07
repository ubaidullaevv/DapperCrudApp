using Models;
namespace Interface;

public interface IGroupService
{
    public bool CreateGroup(Group group);
    public bool UpdateGroup(Group group);
    public bool DeleteGroup(int id);
    public void DisplayGroups();
}