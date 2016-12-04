namespace CF.Models.Database
{

    // BackerProject
    public class BackerProject
    {
        public int Id { get; set; } // Id (Primary key)
        public int ProjectId { get; set; } // ProjectId
        public int UserId { get; set; } // UserId
        public int Amount { get; set; } // Amount

        public System.DateTime DateInserted { get; set; } // DateInserted
        public string PaymentStatus { get; set; } // PaymentStatus (length: 50)

        // Foreign keys
        public virtual Project Project { get; set; } // FK_BackerProject_Project
        public virtual User User { get; set; } // FK_BackerProject_User
    }

}
// </auto-generated>
