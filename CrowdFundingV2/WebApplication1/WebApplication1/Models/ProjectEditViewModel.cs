using CF.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProjectEditViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string CreatorFullName { get; set; }
        public DateTime DateInserted { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TargetAmount { get; set; }
        public int Ratio { get; set; }

        public int CurrentBackerCount { get; set; }

        public decimal CurrentFund { get; set; }

        public string Description { get; set; }

        public List<Reward> Rewards { get; set; }

        public List<ProjectUpdateViewModel> Updates { get; set; }
        public List<ProjectCommentViewModel> Comments { get; set; }

        public List<BackerViewModel> Backers { get; set; }

        public int DaysLeft
        {
            get
            {
                return (DueDate - DateTime.Now).Days;
            }
        }

        public List<Category> Categories { get; set; }
        public int SelectedCategoryId { get; set; }
        public int SelectedStatusId { get; set; }
        public List<ProjectStatu> Statuses { get; set; }
        public int NoProjects { get; set; }

        public Project Project { get; set; }

        public IEnumerable<BasicProjectInfoViewModel> MyProjects { get; set; }

        public int CreatorNoProjects { get; set; }
        public int CreatorId { get; set; }
        public string CreatorImageUrl { get; set; }
        public string ProjectImageUrl { get; set; }
    }
}