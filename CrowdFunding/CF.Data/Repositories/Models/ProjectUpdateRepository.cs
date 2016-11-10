using CF.Data.Context;
using CF.Models.Database;

namespace CF.Data.Repositories.Models
{
    public class ProjectUpdateRepository : Repository<ProjectUpdate>, IProjectUpdateRepository
    {
        public ProjectUpdateRepository(ICrowdFundingDbContext context) : base(context)
        {
        }
    }
}
