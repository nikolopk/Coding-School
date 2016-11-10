using CF.Data.Context;
using CF.Models.Database;

namespace CF.Data.Repositories.Models
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ICrowdFundingDbContext context) : base(context)
        {
        }
    }
}
