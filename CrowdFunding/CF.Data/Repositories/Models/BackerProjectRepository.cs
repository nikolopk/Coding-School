using CF.Data.Context;
using CF.Models.Database;

namespace CF.Data.Repositories.Models
{
    public class BackerProjectRepository : Repository<BackerProject>, IBackerProjectRepository
    {
        public BackerProjectRepository(ICrowdFundingDbContext context) : base(context)
        {
        }
    }
}
