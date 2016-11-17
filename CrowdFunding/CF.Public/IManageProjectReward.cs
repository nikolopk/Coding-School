using CF.Models.MVC.ProjectReward;

namespace CF.Public
{
    public interface IManageProjectReward
    {
        ProjectRewardViewModel GetProjectReward(int rewardId);

        ProjectRewardListViewModel GetProjectRewardList(int projectId);
    }
}
