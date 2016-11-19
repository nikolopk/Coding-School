using System.Collections.Generic;

namespace CF.Models.MVC.ProjectReward
{
    public class ProjectRewardListViewModel : ICachableModel
    {
        public int ProjectId { get; set; }
        public List<ProjectRewardViewModel> Rewards { get; set; }
    }
}
