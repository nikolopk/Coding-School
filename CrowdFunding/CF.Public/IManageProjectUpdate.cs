using CF.Models.MVC.ProjectUpdate;

namespace CF.Public
{
    public interface IManageProjectUpdate
    {
        ProjectUpdateViewModel GetProjectUpdate(int updateId);

        ProjectUpdateListViewModel GetProjectUpdateList(int projectId);
    }
}
