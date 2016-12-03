using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RewardViewModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Required Amount")]
        public decimal RequiredAmount { get; set; } 

        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        [Display(Name = "Max Available")]
        public int MaxAvailable { get; set; }
        public int CurrentAvailable { get; set; }
    }
}