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
            Property(x => x.Email).HasColumnName(@"Email").IsOptional().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.Password).HasColumnName(@"Password").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.FirstName).HasColumnName(@"FirstName").IsOptional().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.LastName).HasColumnName(@"LastName").IsOptional().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.PhotoUrl).HasColumnName(@"PhotoUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.CardNumber).HasColumnName(@"CardNumber").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.ExpirationDate).HasColumnName(@"ExpirationDate").IsOptional().HasColumnType("datetime");
            Property(x => x.SecurityCode).HasColumnName(@"SecurityCode").IsOptional().HasColumnType("smallint");
            Property(x => x.VerificationGuid).HasColumnName(@"VerificationGuid").IsOptional().HasColumnType("uniqueidentifier");
            Property(x => x.IsVerified).HasColumnName(@"IsVerified").IsOptional().HasColumnType("bit");
            Property(x => x.AspNetUsersId).HasColumnName(@"AspNetUsersId").IsOptional().HasColumnType("nvarchar").HasMaxLength(128);

            // Foreign keys
            HasOptional(a => a.AspNetUser).WithMany(b => b.Users).HasForeignKey(c => c.AspNetUsersId).WillCascadeOnDelete(false); // FK_User_AspNetUsers
        }
    }

}
// </auto-generated>
