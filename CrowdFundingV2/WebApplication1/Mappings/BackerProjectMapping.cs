using CF.Models.Database;

namespace CF.Data.Mappings
{

    // BackerProject
    public class BackerProjectMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BackerProject>
    {
        public BackerProjectMapping()
            : this("dbo")
        {
        }

        public BackerProjectMapping(string schema)
        {
            ToTable("BackerProject", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectId).HasColumnName(@"ProjectId").IsRequired().HasColumnType("int");
            Property(x => x.UserId).HasColumnName(@"UserId").IsRequired().HasColumnType("int");
            Property(x => x.Amount).HasColumnName(@"Amount").IsRequired().HasColumnType("decimal").HasPrecision(18,2);
            Property(x => x.DateInserted).HasColumnName(@"DateInserted").IsRequired().HasColumnType("datetime");
            Property(x => x.PaymentStatus).HasColumnName(@"PaymentStatus").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.BackerProjects).HasForeignKey(c => c.ProjectId).WillCascadeOnDelete(false); // FK_BackerProject_Project
            HasRequired(a => a.User).WithMany(b => b.BackerProjects).HasForeignKey(c => c.UserId).WillCascadeOnDelete(false); // FK_BackerProject_User
        }
    }

}
// </auto-generated>
