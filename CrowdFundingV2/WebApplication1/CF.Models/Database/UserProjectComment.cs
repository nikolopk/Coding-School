namespace CF.Models.Database
{

    // UserProjectComment
    public class UserProjectComment
    {
        public int Id { get; set; } // Id (Primary key)
        public int BackerId { get; set; } // BackerId
        public int ProjectId { get; set; } // ProjectId
        public string Text { get; set; } // Text (length: 500)
        public System.DateTime DateInserted { get; set; } // DateInserted

        // Foreign keys
        public virtual Project Project { get; set; } // FK_UserProjectComment_Project
        public virtual User User { get; set; } // FK_UserProjectComment_User
    }

}
// </auto-generated>
