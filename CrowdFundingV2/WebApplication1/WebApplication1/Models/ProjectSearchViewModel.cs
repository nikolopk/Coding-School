using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class ProjectSearchViewModel
    {
        public string Query { get; set; }
        public int NoProjects { get; set; }
        public List<BasicProjectInfoViewModel> DisplayProjects { get; set; }
        
    }
}