using System;

namespace CF.Models.MVC.ProjectUpdate
{
    public class ProjectUpdateViewModel : ICachableModel
    {
        public int ProjectUpdateId { get; set; }
        public string CreatorFullName { get; set; }

        public string CreatorImageUrl { get; set; }

        public string Text { get; set; }

        public DateTime DateTimeInserted { get; set; }
    }
}
