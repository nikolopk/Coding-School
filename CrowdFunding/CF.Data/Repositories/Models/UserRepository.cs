using CF.Data.Context;
using CF.Models.Database;

namespace CF.Data.Repositories.Models
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ICrowdFundingDbContext context) : base(context)
        {
        }
    }
}
