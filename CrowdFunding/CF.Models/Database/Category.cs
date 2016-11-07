
namespace CF.Models.Database
{

    // Category
    public class Category
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<Project> Projects { get; set; } // Project.FK_Project_Category

        public Category()
        {
            Projects = new System.Collections.Generic.List<Project>();
        }
    }

}
// </auto-generated>
