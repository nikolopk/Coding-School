using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF.MVC.Models
{
    public class RewardViewModel
    {
        public int Id { get; set; } // Id (Primary key)
        public int ProjectId { get; set; } // ProjectId
        public string Name { get; set; } // Name (length: 50)
        public System.DateTime DateInserted { get; set; } // DateInserted
        public string Description { get; set; } // Description (length: 50)
        public decimal RequiredAmount { get; set; } // RequiredAmount
        public int MaxAvailable { get; set; } // MaxAvailable
        public int CurrentAvailable { get; set; } // CurrentAvailable
        public bool IsAvailable { get; set; } // IsAvailable
    }
}