namespace CF.Models.MVC.Project
{
    public class BasicProjectInfoViewModel : ICachableModel
    {
        public string Title { get; set; }
        public string CreatorFullName { get; set; }
        public string ImageUrl { get; set; }
        public int Ratio { get; set; }

        public int CurrentBackerCount { get; set; }

        public int DaysLeft { get; set; }
    }
}
