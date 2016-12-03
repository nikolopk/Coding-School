using CF.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RewardViewModel
    {
        public int Id { get; set; } // Id (Primary key)
        public int ProjectId { get; set; } // ProjectId
        public string Name { get; set; } // Name (length: 50)
        public string Description { get; set; } // Description (length: 50)
        [Display(Name = "Required Amount")]
        public decimal RequiredAmount { get; set; } // RequiredAmount
        [Display(Name = "Max Available")]
        public int MaxAvailable { get; set; } // MaxAvailable
    }
}