// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

namespace CF.POCOGenerator
{

    // User
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
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
            Property(x => x.Email).HasColumnName(@"Email").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.Password).HasColumnName(@"Password").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.FirstName).HasColumnName(@"FirstName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.LastName).HasColumnName(@"LastName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.PhotoUrl).HasColumnName(@"PhotoUrl").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.CardNumber).HasColumnName(@"CardNumber").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.ExpirationDate).HasColumnName(@"ExpirationDate").IsRequired().HasColumnType("datetime");
            Property(x => x.SecurityCode).HasColumnName(@"SecurityCode").IsRequired().HasColumnType("smallint");
            Property(x => x.VerificationGuid).HasColumnName(@"VerificationGuid").IsOptional().HasColumnType("uniqueidentifier");
            Property(x => x.IsVerified).HasColumnName(@"IsVerified").IsRequired().HasColumnType("bit");
        }
    }

}
// </auto-generated>
