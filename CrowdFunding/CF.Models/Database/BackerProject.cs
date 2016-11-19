namespace CF.Models.Database
{

    // BackerProject
    public class BackerProject : ICachableModel
    {
        public int Id { get; set; } // Id (Primary key)
        public int ProjectId { get; set; } // ProjectId
        public int UserId { get; set; } // UserId
        public decimal Amount { get; set; } // Amount
        public System.DateTime DateInserted { get; set; } // DateInserted

        // Foreign keys
        public virtual Project Project { get; set; } // FK_BackerProject_Project
        public virtual User User { get; set; } // FK_BackerProject_User
    }
}
