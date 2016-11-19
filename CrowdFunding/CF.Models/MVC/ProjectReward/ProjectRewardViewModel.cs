namespace CF.Models.MVC.ProjectReward
{
    public class ProjectRewardViewModel : ICachableModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CurrentAvailable { get; set; }
        public int MaxAvailable { get; set; }
    }
}
