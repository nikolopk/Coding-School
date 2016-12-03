namespace CF.Data.Context
{
    using Mappings;
    using Models.Database;
    using System.Linq;

    public class CrowdFundingContext : System.Data.Entity.DbContext, ICrowdFundingContext
    {
        public System.Data.Entity.DbSet<AspNetRole> AspNetRoles { get; set; } // AspNetRoles
        public System.Data.Entity.DbSet<AspNetUser> AspNetUsers { get; set; } // AspNetUsers
        public System.Data.Entity.DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } // AspNetUserClaims
        public System.Data.Entity.DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } // AspNetUserLogins
        public System.Data.Entity.DbSet<BackerProject> BackerProjects { get; set; } // BackerProject
        public System.Data.Entity.DbSet<Category> Categories { get; set; } // Category
        public System.Data.Entity.DbSet<Project> Projects { get; set; } // Project
        public System.Data.Entity.DbSet<ProjectStatu> ProjectStatus { get; set; } // ProjectStatus
        public System.Data.Entity.DbSet<ProjectUpdate> ProjectUpdates { get; set; } // ProjectUpdate
        public System.Data.Entity.DbSet<Reward> Rewards { get; set; } // Reward
        public System.Data.Entity.DbSet<User> Users { get; set; } // User
        public System.Data.Entity.DbSet<UserProjectComment> UserProjectComments { get; set; } // UserProjectComment

        static CrowdFundingContext()
        {
            System.Data.Entity.Database.SetInitializer<CrowdFundingContext>(null);
        }

        public CrowdFundingContext()
            : base("Name=CrowdFunding")
        {
        }

        public CrowdFundingContext(string connectionString)
            : base(connectionString)
        {
        }

        public CrowdFundingContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        public CrowdFundingContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public CrowdFundingContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AspNetRoleMapping());
            modelBuilder.Configurations.Add(new AspNetUserMapping());
            modelBuilder.Configurations.Add(new AspNetUserClaimMapping());
            modelBuilder.Configurations.Add(new AspNetUserLoginMapping());
            modelBuilder.Configurations.Add(new BackerProjectMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new ProjectMapping());
            modelBuilder.Configurations.Add(new ProjectStatuMapping());
            modelBuilder.Configurations.Add(new ProjectUpdateMapping());
            modelBuilder.Configurations.Add(new RewardMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new UserProjectCommentMapping());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMapping(schema));
            modelBuilder.Configurations.Add(new AspNetUserMapping(schema));
            modelBuilder.Configurations.Add(new AspNetUserClaimMapping(schema));
            modelBuilder.Configurations.Add(new AspNetUserLoginMapping(schema));
            modelBuilder.Configurations.Add(new BackerProjectMapping(schema));
            modelBuilder.Configurations.Add(new CategoryMapping(schema));
            modelBuilder.Configurations.Add(new ProjectMapping(schema));
            modelBuilder.Configurations.Add(new ProjectStatuMapping(schema));
            modelBuilder.Configurations.Add(new ProjectUpdateMapping(schema));
            modelBuilder.Configurations.Add(new RewardMapping(schema));
            modelBuilder.Configurations.Add(new UserMapping(schema));
            modelBuilder.Configurations.Add(new UserProjectCommentMapping(schema));
            return modelBuilder;
        }

        public System.Data.Entity.DbSet<CF.Models.MVC.Project.ProjectCreatorBasicInfoProfileViewModel> ProjectCreatorBasicInfoProfileViewModels { get; set; }
    }
}
// </auto-generated>
