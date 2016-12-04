using CF.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.Public
{
    public interface IManageProject
    {
        IQueryable<Project> GetAll();
        IQueryable<Project> GetByCreator(int creatorId);
    }
}
