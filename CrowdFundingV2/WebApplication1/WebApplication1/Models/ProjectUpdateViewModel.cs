using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProjectUpdateViewModel
    {
        public int ProjectId { get; set; }
        public string FullName { get; set; }

        public string Text { get; set; }
        public DateTime DateInserted { get; set; }
    }
}