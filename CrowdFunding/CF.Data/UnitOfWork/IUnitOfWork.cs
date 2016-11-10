using CF.Data.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.Data.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        // Repository interfaces with pluralized properties; to emulate the DbSet<> properties of the DbContext!
        IBackerProjectRepository BackerProjects { get; }
        ICategoryRepository Categories { get;  }
        IProjectRepository Projects { get; }
        IProjectStatusRepository ProjectStatuses { get; }
        IProjectUpdateRepository ProjectUpdates { get; }
        IRewardRepository Rewards { get; }
        IUserProjectCommentRepository UserProjectComments { get; }
        IUserRepository Users { get; }

        // UoW methods
        void ExecuteSql(string sql, params object[] parameters);
        void SaveChanges();
        void Commit();
        void Rollback();
    }
}
