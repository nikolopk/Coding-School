using CF.Data.Context;
using CF.Models.Database;
using CF.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Entity;

namespace CF.EntityManagers
{
    public class ProjectManager : IManageProject
    {
        private readonly CrowdFundingContext db = new CrowdFundingContext();
        public IQueryable<Project> GetAll()
        {
            return db.Projects
                           .Include(p => p.User)
                           .Include(p => p.BackerProjects)
                           .Include(p => p.UserProjectComments)
                           .Include(p => p.ProjectUpdates);
        }

        public IQueryable<Project> GetByCreator(int creatorId)
        {
            return db.Projects
                           .Include(p => p.User)
                           .Include(p => p.BackerProjects)
                           .Include(p => p.UserProjectComments)
                           .Include(p => p.ProjectUpdates)
                           .Where(p => p.CreatorId == creatorId);
        }

    }
}
