using CF.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProjectViewModel
    {
        public List<Category> Categories { get; set; }
        public List<User> Users { get; set; }
        public List<ProjectStatus> Statuses { get; set; }
        public Project Project { get; set; }
    }
}