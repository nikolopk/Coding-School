using CF.Data.Context;
using CF.Models.Database;

namespace CF.Data.Repositories.Models
{
    public class UserProjectCommentRepository : Repository<UserProjectComment>, IUserProjectCommentRepository
    {
        public UserProjectCommentRepository(ICrowdFundingDbContext context) : base(context)
        {
        }
    }
}
