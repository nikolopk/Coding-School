namespace CF.Models.MVC.Project
{
    public class ProjectAboutViewModel : ICachableModel
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }

        public string CreatorFullName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
