using CF.Data.Context;
using CF.Models.Database;

namespace CF.Data.Repositories.Models
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(ICrowdFundingDbContext context) : base(context)
        {
        }
    }
}
