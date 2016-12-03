using CF.Public;
using System;
using CF.Models.MVC.ProjectUpdate;

namespace CF.EntityManagers
{
    public class ProjectUpdateIManager : IManageProjectUpdate
    {
        public ProjectUpdateViewModel GetProjectUpdate(int updateId)
        {
            throw new NotImplementedException();
        }

        public ProjectUpdateListViewModel GetProjectUpdateList(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
