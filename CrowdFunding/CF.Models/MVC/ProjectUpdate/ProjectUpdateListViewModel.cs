using System.Collections.Generic;

namespace CF.Models.MVC.ProjectUpdate
{
    public class ProjectUpdateListViewModel : ICachableModel
    {
        public int ProjectId { get; set; }
        public List<ProjectUpdateViewModel> Updates { get; set; }
    }
}
