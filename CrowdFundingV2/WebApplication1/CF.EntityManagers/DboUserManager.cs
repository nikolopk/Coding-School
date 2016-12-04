using CF.Data.Context;
using CF.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.EntityManagers
{
    public class DboUserManager : IManageDboUser
    {
        private readonly CrowdFundingContext db = new CrowdFundingContext();
        
        public async Task CreateDboUser(string id)
        {
            var user = db.Users.Where(x => x.AspNetUsersId == id).FirstOrDefault();

            if(user == null)
            {
                user = new Models.Database.User()
                {
                    AspNetUsersId = id
                };
                db.Users.Add(user);
                
                await db.SaveChangesAsync();
            }
        }
    }
}
