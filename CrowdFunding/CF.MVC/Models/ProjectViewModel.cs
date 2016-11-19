using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CF.MVC.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title (length: 200)
        public string Description { get; set; } // Description (length: 2147483647)
        [Display(Name = "Category")]
        public int CategoryId { get; set; } // CategoryId
        [Display(Name = "Due Date")]
        public System.DateTime DueDate { get; set; } // DueDate
        [Display(Name = "Target Amount")]
        public decimal TargetAmount { get; set; } // TargetAmount
        [Display(Name = "Verified?")]
        public bool isVerified { get; set; }
        public System.Collections.Generic.ICollection<RewardViewModel> Rewards { get; set; } // Reward.FK_Reward_Project
        
    }
}