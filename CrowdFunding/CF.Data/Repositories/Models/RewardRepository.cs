using CF.Data.Context;
using CF.Models.Database;

namespace CF.Data.Repositories.Models
{
    public class RewardRepository : Repository<Reward>
    {
        public RewardRepository(ICrowdFundingDbContext context) : base(context)
        {
        }
    }
}
