using CF.Models.Database;

namespace CF.Data.Mappings
{

    // AspNetRoles
    public class AspNetRoleMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AspNetRole>
    {
        public AspNetRoleMapping()
            : this("dbo")
        {
        }

        public AspNetRoleMapping(string schema)
        {
            ToTable("AspNetRoles", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("nvarchar").HasMaxLength(128).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName(@"Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            HasMany(t => t.AspNetUsers).WithMany(t => t.AspNetRoles).Map(m =>
            {
                m.ToTable("AspNetUserRoles", "dbo");
                m.MapLeftKey("RoleId");
                m.MapRightKey("UserId");
            });
        }
    }

}
// </auto-generated>
