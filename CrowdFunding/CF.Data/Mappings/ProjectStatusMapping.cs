using CF.Models.Database;
namespace CF.Data.Mappings
{

    // ProjectStatus
    public class ProjectStatusMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ProjectStatus>
    {
        public ProjectStatusMapping()
            : this("dbo")
        {
        }

        public ProjectStatusMapping(string schema)
        {
            ToTable("ProjectStatus", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName(@"Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
        }
    }

}
// </auto-generated>
