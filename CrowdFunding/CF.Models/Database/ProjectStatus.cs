namespace CF.Models.Database
{
    // ProjectStatus
    public class ProjectStatus
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<Project> Projects { get; set; } // Project.FK_Project_ProjectStatus

        public ProjectStatus()
        {
            Projects = new System.Collections.Generic.List<Project>();
        }
    }
}
