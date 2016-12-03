using CF.Models.Database;

namespace CF.Data.Mappings
{

    // User
    public class UserMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<User>
    {
        public UserMapping()
            : this("dbo")
        {
        }

        public UserMapping(string schema)
        {
            ToTable("User", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.PhotoUrl).HasColumnName(@"PhotoUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.AspNetUsersId).HasColumnName(@"AspNetUsersId").IsOptional().HasColumnType("nvarchar").HasMaxLength(128);

            // Foreign keys
            HasOptional(a => a.AspNetUser).WithMany(b => b.Users).HasForeignKey(c => c.AspNetUsersId).WillCascadeOnDelete(false); // FK_User_AspNetUsers
        }
    }

}
// </auto-generated>
