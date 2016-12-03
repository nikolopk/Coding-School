using CF.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CF.Models.MVC.ProjectComment;

namespace CF.EntityManagers
{
    public class ProjectCommentManager : IManageProjectComment
    {
        public ProjectCommentViewModel GetProjectComment(int commentId)
        {
            throw new NotImplementedException();
        }

        public ProjectCommentListViewModel GetProjectCommentList(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
