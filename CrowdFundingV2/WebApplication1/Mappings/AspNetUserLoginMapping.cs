using CF.Models.Database;

namespace CF.Data.Mappings
{

    // AspNetUserLogins
    public class AspNetUserLoginMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AspNetUserLogin>
    {
        public AspNetUserLoginMapping()
            : this("dbo")
        {
        }

        public AspNetUserLoginMapping(string schema)
        {
            ToTable("AspNetUserLogins", schema);
            HasKey(x => new { x.LoginProvider, x.ProviderKey, x.UserId });

            Property(x => x.LoginProvider).HasColumnName(@"LoginProvider").IsRequired().HasColumnType("nvarchar").HasMaxLength(128).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ProviderKey).HasColumnName(@"ProviderKey").IsRequired().HasColumnType("nvarchar").HasMaxLength(128).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.UserId).HasColumnName(@"UserId").IsRequired().HasColumnType("nvarchar").HasMaxLength(128).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.AspNetUser).WithMany(b => b.AspNetUserLogins).HasForeignKey(c => c.UserId); // FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId
        }
    }

}
// </auto-generated>
