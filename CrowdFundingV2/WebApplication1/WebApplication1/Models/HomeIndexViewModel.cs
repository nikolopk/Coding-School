using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class HomeIndexViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public BasicProjectInfoViewModel TopProject { get; set; }
        public List<BasicProjectInfoViewModel> PopularProjects { get; set; }
    }
}