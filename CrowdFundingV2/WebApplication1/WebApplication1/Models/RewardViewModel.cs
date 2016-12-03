using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RewardViewModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public int MaxAvailable { get; set; }
        public int CurrentAvailable { get; set; }
    }
}