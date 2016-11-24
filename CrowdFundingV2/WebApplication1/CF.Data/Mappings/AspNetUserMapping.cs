using CF.Models.Database;

namespace CF.Data.Mappings
{

    // AspNetUsers
    public class AspNetUserMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AspNetUser>
    {
        public AspNetUserMapping()
            : this("dbo")
        {
        }

        public AspNetUserMapping(string schema)
        {
            ToTable("AspNetUsers", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("nvarchar").HasMaxLength(128).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Email).HasColumnName(@"Email").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.EmailConfirmed).HasColumnName(@"EmailConfirmed").IsRequired().HasColumnType("bit");
            Property(x => x.PasswordHash).HasColumnName(@"PasswordHash").IsOptional().HasColumnType("nvarchar(max)");
            Property(x => x.SecurityStamp).HasColumnName(@"SecurityStamp").IsOptional().HasColumnType("nvarchar(max)");
            Property(x => x.PhoneNumber).HasColumnName(@"PhoneNumber").IsOptional().HasColumnType("nvarchar(max)");
            Property(x => x.PhoneNumberConfirmed).HasColumnName(@"PhoneNumberConfirmed").IsRequired().HasColumnType("bit");
            Property(x => x.TwoFactorEnabled).HasColumnName(@"TwoFactorEnabled").IsRequired().HasColumnType("bit");
            Property(x => x.LockoutEndDateUtc).HasColumnName(@"LockoutEndDateUtc").IsOptional().HasColumnType("datetime");
            Property(x => x.LockoutEnabled).HasColumnName(@"LockoutEnabled").IsRequired().HasColumnType("bit");
            Property(x => x.AccessFailedCount).HasColumnName(@"AccessFailedCount").IsRequired().HasColumnType("int");
            Property(x => x.UserName).HasColumnName(@"UserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.FirstName).HasColumnName(@"FirstName").IsOptional().HasColumnType("nvarchar(max)");
            Property(x => x.LastName).HasColumnName(@"LastName").IsOptional().HasColumnType("nvarchar(max)");
        }
    }

}
// </auto-generated>
