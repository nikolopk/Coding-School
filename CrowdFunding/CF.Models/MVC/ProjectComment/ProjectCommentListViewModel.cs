using System.Collections.Generic;

namespace CF.Models.MVC.ProjectComment
{
    public class ProjectCommentListViewModel : ICachableModel
    {
        public int ProjectId { get; set; }
        public List<ProjectCommentViewModel> Comments { get; set; }
    }
}
