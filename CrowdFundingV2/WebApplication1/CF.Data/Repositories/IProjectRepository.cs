using CF.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.Data.Repositories
{
    public interface IProjectRepository
    {
        IEnumerable<Project> Projects { get; set; }
    }
}
