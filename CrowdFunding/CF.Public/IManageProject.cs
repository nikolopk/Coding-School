using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CF.Models.MVC.Project;

namespace CF.Public
{
    public interface IManageProject
    {
        void CreateProject();
        BasicProjectInfoViewModel GetBasicProjectInfo(int projectId);

        ProjectCreatorBasicInfoProfileViewModel GetProjectCreatorBasicInfoProfile(int projectId);

        ProjectAboutViewModel GetAboutProject(int projectId);

        ProjectBackDisplayViewModel GetProjectBackDisplay(int projectId);

    }
}
