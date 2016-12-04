using CF.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProjectEditViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        public string CreatorFullName { get; set; }
        public DateTime DateInserted { get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int TargetAmount { get; set; }
        public int Ratio { get; set; }

        public int CurrentBackerCount { get; set; }

        public decimal CurrentFund { get; set; }

        [Required]
        public string Description { get; set; }

        public List<RewardViewModel> Rewards { get; set; }

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