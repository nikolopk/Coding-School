using CF.Data.Context;
using CF.Models.Database;

namespace CF.Data.Repositories.Models
{
    public class ProjectStatusRepository : Repository<ProjectStatus>, IProjectStatusRepository
    {
        public ProjectStatusRepository(ICrowdFundingDbContext context) : base(context)
        {
        }
    }
}
