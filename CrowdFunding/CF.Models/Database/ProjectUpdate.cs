namespace CF.Models.Database
{
    // ProjectUpdate
    public class ProjectUpdate
    {
        public int Id { get; set; } // Id (Primary key)
        public int ProjectId { get; set; } // ProjectId
        public string Text { get; set; } // Text (length: 500)
        public System.DateTime DateInserted { get; set; } // DateInserted

        // Foreign keys
        public virtual Project Project { get; set; } // FK_ProjectUpdate_Project
    }
}
