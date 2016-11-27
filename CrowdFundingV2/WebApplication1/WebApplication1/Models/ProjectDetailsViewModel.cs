using CF.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProjectDetailsViewModel
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

        public int DaysLeft
        {
            get
            {
                return (DueDate - DateTime.Now).Days;
            }
        }
        
        public int CreatorNoProjects { get; set; }
        public int CreatorId { get; set; }
        public string CreatorImageUrl { get; set; }
        public string ProjectImageUrl { get; set; }
    }
}