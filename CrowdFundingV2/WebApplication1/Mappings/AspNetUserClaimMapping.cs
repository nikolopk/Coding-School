using CF.Models.Database;

namespace CF.Data.Mappings
{

    // AspNetUserClaims
    public class AspNetUserClaimMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AspNetUserClaim>
    {
        public AspNetUserClaimMapping()
            : this("dbo")
        {
        }

        public AspNetUserClaimMapping(string schema)
        {
            ToTable("AspNetUserClaims", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UserId).HasColumnName(@"UserId").IsRequired().HasColumnType("nvarchar").HasMaxLength(128);
            Property(x => x.ClaimType).HasColumnName(@"ClaimType").IsOptional().HasColumnType("nvarchar(max)");
            Property(x => x.ClaimValue).HasColumnName(@"ClaimValue").IsOptional().HasColumnType("nvarchar(max)");

            // Foreign keys
            HasRequired(a => a.AspNetUser).WithMany(b => b.AspNetUserClaims).HasForeignKey(c => c.UserId); // FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId
        }
    }

}
// </auto-generated>
