namespace CF.Models.MVC.Project
{
    public class ProjectCreatorBasicInfoProfileViewModel : ICachableModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string FullName { get; set; }

        public int ProjectCount { get; set; }
    }
}
