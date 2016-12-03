using CF.Models.Database;
namespace CF.Data2.Mappings
{
    // UserProjectComment
    public class UserProjectCommentMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UserProjectComment>
    {
        public UserProjectCommentMapping()
            : this("dbo")
        {
        }

        public UserProjectCommentMapping(string schema)
        {
            ToTable("UserProjectComment", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.BackerId).HasColumnName(@"BackerId").IsRequired().HasColumnType("int");
            Property(x => x.ProjectId).HasColumnName(@"ProjectId").IsRequired().HasColumnType("int");
            Property(x => x.Text).HasColumnName(@"Text").IsRequired().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.DateInserted).HasColumnName(@"DateInserted").IsRequired().HasColumnType("datetime");

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.UserProjectComments).HasForeignKey(c => c.ProjectId).WillCascadeOnDelete(false); // FK_UserProjectComment_Project
            HasRequired(a => a.User).WithMany(b => b.UserProjectComments).HasForeignKey(c => c.BackerId).WillCascadeOnDelete(false); // FK_UserProjectComment_User
        }
    }

}
// </auto-generated>
