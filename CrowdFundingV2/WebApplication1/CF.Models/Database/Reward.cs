namespace CF.Models.Database
{

    // Reward
    public class Reward
    {
        public int Id { get; set; } // Id (Primary key)
        public int ProjectId { get; set; } // ProjectId
        public string Name { get; set; } // Name (length: 50)
        public System.DateTime DateInserted { get; set; } // DateInserted
        public string Description { get; set; } // Description (length: 50)
        public int MinRequiredAmount { get; set; } // MinRequiredAmount
        public int MaxAvailable { get; set; } // MaxAvailable
        public int CurrentAvailable { get; set; } // CurrentAvailable
        public bool IsAvailable { get; set; } // IsAvailable
        public int MaxRequiredAmount { get; set; } // MaxRequiredAmount

        // Foreign keys
        public virtual Project Project { get; set; } // FK_Reward_Project
    }

}
// </auto-generated>
