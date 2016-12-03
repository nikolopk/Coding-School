using CF.Models.Database;

namespace CF.Data.Mappings
{

    // Project
    public class ProjectMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Project>
    {
        public ProjectMapping()
            : this("dbo")
        {
        }

        public ProjectMapping(string schema)
        {
            ToTable("Project", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CreatorId).HasColumnName(@"CreatorId").IsRequired().HasColumnType("int");
            Property(x => x.Title).HasColumnName(@"Title").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.Description).HasColumnName(@"Description").IsRequired().IsUnicode(false).HasColumnType("text").HasMaxLength(2147483647);
            Property(x => x.StatusId).HasColumnName(@"StatusId").IsRequired().HasColumnType("int");
            Property(x => x.CategoryId).HasColumnName(@"CategoryId").IsRequired().HasColumnType("int");
            Property(x => x.DueDate).HasColumnName(@"DueDate").IsRequired().HasColumnType("datetime");
            Property(x => x.TargetAmount).HasColumnName(@"TargetAmount").IsRequired().HasColumnType("int");
            Property(x => x.CurrentFundAmount).HasColumnName(@"CurrentFundAmount").IsRequired().HasColumnType("int");
            Property(x => x.Ratio).HasColumnName(@"Ratio").IsRequired().HasColumnType("decimal").HasPrecision(7, 2);
            Property(x => x.DateInserted).HasColumnName(@"DateInserted").IsRequired().HasColumnType("datetime");
            Property(x => x.DateVerified).HasColumnName(@"DateVerified").IsOptional().HasColumnType("datetime");
            Property(x => x.VerificationGuid).HasColumnName(@"VerificationGuid").IsOptional().HasColumnType("uniqueidentifier");
            Property(x => x.Image).HasColumnName(@"Image").IsOptional().HasColumnType("varbinary");
            Property(x => x.PhotoUrl).HasColumnName(@"PhotoUrl").IsOptional().HasColumnType("nvarchar(max)");

            // Foreign keys
            HasRequired(a => a.Category).WithMany(b => b.Projects).HasForeignKey(c => c.CategoryId).WillCascadeOnDelete(false); // FK_Project_Category
            HasRequired(a => a.ProjectStatu).WithMany(b => b.Projects).HasForeignKey(c => c.StatusId).WillCascadeOnDelete(false); // FK_Project_ProjectStatus
            HasRequired(a => a.User).WithMany(b => b.Projects).HasForeignKey(c => c.CreatorId).WillCascadeOnDelete(false); // FK_Project_User
        }
    }

}
// </auto-generated>
