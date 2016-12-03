using System;

namespace CF.Models.MVC.Project
{
    public class ProjectBackDisplayViewModel : ICachableModel
    {
        public int ProjectId { get; set; }
        public DateTime DateVerified { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TargetAmount { get; set; }
    }
}
