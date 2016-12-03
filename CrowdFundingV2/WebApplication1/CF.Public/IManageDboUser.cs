using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.Public
{
    public interface IManageDboUser
    {
        Task CreateDboUser(string id);
    }
}
