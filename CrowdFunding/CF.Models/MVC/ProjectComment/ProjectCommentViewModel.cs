using System;

namespace CF.Models.MVC.ProjectComment
{
    public class ProjectCommentViewModel : ICachableModel
    {
        public int ProjectCommentId { get; set; }
        public string CommentorFullName { get; set; }
        public string CommentorImageUrl { get; set; }
        public string Text { get; set; }
        public DateTime DateTimeInserted { get; set; }
    }
}
