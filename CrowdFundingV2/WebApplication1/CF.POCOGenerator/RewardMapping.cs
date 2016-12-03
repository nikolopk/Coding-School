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

    // Reward
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class RewardMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Reward>
    {
        public RewardMapping()
            : this("dbo")
        {
        }

        public RewardMapping(string schema)
        {
            ToTable("Reward", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectId).HasColumnName(@"ProjectId").IsRequired().HasColumnType("int");
            Property(x => x.Name).HasColumnName(@"Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.DateInserted).HasColumnName(@"DateInserted").IsRequired().HasColumnType("datetime");
            Property(x => x.Description).HasColumnName(@"Description").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.MinRequiredAmount).HasColumnName(@"MinRequiredAmount").IsRequired().HasColumnType("int");
            Property(x => x.MaxAvailable).HasColumnName(@"MaxAvailable").IsRequired().HasColumnType("int");
            Property(x => x.CurrentAvailable).HasColumnName(@"CurrentAvailable").IsRequired().HasColumnType("int");
            Property(x => x.IsAvailable).HasColumnName(@"IsAvailable").IsRequired().HasColumnType("bit");
            Property(x => x.MaxRequiredAmount).HasColumnName(@"MaxRequiredAmount").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.Rewards).HasForeignKey(c => c.ProjectId).WillCascadeOnDelete(false); // FK_Reward_Project
        }
    }

}
// </auto-generated>
