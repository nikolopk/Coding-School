using CF.Models.MVC.ProjectComment;

namespace CF.Public
{
    public interface IManageProjectComment
    {
        ProjectCommentViewModel GetProjectComment(int commentId);

        ProjectCommentListViewModel GetProjectCommentList(int projectId);
    }
}
