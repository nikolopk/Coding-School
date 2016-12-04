using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoProjects { get; set; }
        public List<BasicProjectInfoViewModel> DisplayProjects { get; set; }
        public List<BasicProjectInfoViewModel> StaffProjects { get; set; }
        public List<BasicProjectInfoViewModel> PopularProjects { get; set; }
        public List<BasicProjectInfoViewModel> TodayProjects { get; set; }
        public List<BasicProjectInfoViewModel> FundedProjects { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}