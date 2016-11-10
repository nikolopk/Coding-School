namespace CF.Models.Database
{
    // Project
    public class Project
    {
        public int Id { get; set; } // Id (Primary key)
        public int CreatorId { get; set; } // CreatorId
        public string Title { get; set; } // Title (length: 200)
        public string Description { get; set; } // Description (length: 2147483647)
        public int StatusId { get; set; } // StatusId
        public int CategoryId { get; set; } // CategoryId
        public System.DateTime DueDate { get; set; } // DueDate
        public decimal TargetAmount { get; set; } // TargetAmount
        public decimal CurrentFundAmount { get; set; } // CurrentFundAmount
        public decimal Ratio { get; set; } // Ratio

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<BackerProject> BackerProjects { get; set; } // BackerProject.FK_BackerProject_Project
        public virtual System.Collections.Generic.ICollection<ProjectUpdate> ProjectUpdates { get; set; } // ProjectUpdate.FK_ProjectUpdate_Project
        public virtual System.Collections.Generic.ICollection<Reward> Rewards { get; set; } // Reward.FK_Reward_Project
        public virtual System.Collections.Generic.ICollection<UserProjectComment> UserProjectComments { get; set; } // UserProjectComment.FK_UserProjectComment_Project

        // Foreign keys
        public virtual Category Category { get; set; } // FK_Project_Category
        public virtual ProjectStatus ProjectStatus { get; set; } // FK_Project_ProjectStatus
        public virtual User User { get; set; } // FK_Project_User

        public Project()
        {
            BackerProjects = new System.Collections.Generic.List<BackerProject>();
            ProjectUpdates = new System.Collections.Generic.List<ProjectUpdate>();
            Rewards = new System.Collections.Generic.List<Reward>();
            UserProjectComments = new System.Collections.Generic.List<UserProjectComment>();
        }
    }
}
