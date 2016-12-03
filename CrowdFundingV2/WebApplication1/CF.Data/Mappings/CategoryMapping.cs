using CF.Models.Database;

namespace CF.Data.Mappings
{

    // Category
    public class CategoryMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
            : this("dbo")
        {
        }

        public CategoryMapping(string schema)
        {
            ToTable("Category", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName(@"Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
        }
    }

}
// </auto-generated>
