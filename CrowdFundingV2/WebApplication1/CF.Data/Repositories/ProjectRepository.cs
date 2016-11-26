using CF.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CF.Models.Database;
using System.Data.Entity;

namespace CF.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private CrowdFundingContext dbContext = new CrowdFundingContext();
        //private readonly ICrowdFundingContext _crowdFundingContext;

        //public ProjectRepository(ICrowdFundingContext crowdFundingContext)
        //{
        //    _crowdFundingContext = crowdFundingContext;
        //}

        public IQueryable<Project> Projects
        {
            get
            {
                return dbContext.Projects.Include(p => p.Category).Include(p => p.ProjectStatus).Include(p => p.User);
            }
        }
    }
}
