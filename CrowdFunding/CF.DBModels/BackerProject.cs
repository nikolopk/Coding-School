namespace CF.DBModels
{

    // BackerProject
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class BackerProject
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
// </auto-generated>
