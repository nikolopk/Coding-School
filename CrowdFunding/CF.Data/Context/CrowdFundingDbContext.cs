using CF.Data.Mappings;
using CF.Models.Database;

namespace CF.Data.Context
{
    public class CrowdFundingDbContext : System.Data.Entity.DbContext, ICrowdFundingDbContext
    {
        public System.Data.Entity.IDbSet<BackerProject> BackerProjects { get; set; } // BackerProject
        public System.Data.Entity.IDbSet<Category> Categories { get; set; } // Category
        public System.Data.Entity.IDbSet<Project> Projects { get; set; } // Project
        public System.Data.Entity.IDbSet<ProjectStatus> ProjectStatus { get; set; } // ProjectStatus
        public System.Data.Entity.IDbSet<ProjectUpdate> ProjectUpdates { get; set; } // ProjectUpdate
        public System.Data.Entity.IDbSet<Reward> Rewards { get; set; } // Reward
        public System.Data.Entity.IDbSet<User> Users { get; set; } // User
        public System.Data.Entity.IDbSet<UserProjectComment> UserProjectComments { get; set; } // UserProjectComment

        static CrowdFundingDbContext()
        {
            System.Data.Entity.Database.SetInitializer<CrowdFundingDbContext>(null);
        }

        public CrowdFundingDbContext()
            : base("Name=CrowdFunding")
        {
        }

        //public CrowdFundingDbContext(string connectionString)
        //    : base(connectionString)
        //{
        //}

        //public CrowdFundingDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
        //    : base(connectionString, model)
        //{
        //}

        //public CrowdFundingDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
        //    : base(existingConnection, contextOwnsConnection)
        //{
        //}

        //public CrowdFundingDbContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
        //    : base(existingConnection, model, contextOwnsConnection)
        //{
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose(disposing);
        //}

        //public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        //{
        //    var sqlValue = param.SqlValue;
        //    var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
        //    if (nullableValue != null)
        //        return nullableValue.IsNull;
        //    return (sqlValue == null || sqlValue == System.DBNull.Value);
        //}

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new BackerProjectMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new ProjectMapping());
            modelBuilder.Configurations.Add(new ProjectStatusMapping());
            modelBuilder.Configurations.Add(new ProjectUpdateMapping());
            modelBuilder.Configurations.Add(new RewardMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new UserProjectCommentMapping());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new BackerProjectMapping(schema));
            modelBuilder.Configurations.Add(new CategoryMapping(schema));
            modelBuilder.Configurations.Add(new ProjectMapping(schema));
            modelBuilder.Configurations.Add(new ProjectStatusMapping(schema));
            modelBuilder.Configurations.Add(new ProjectUpdateMapping(schema));
            modelBuilder.Configurations.Add(new RewardMapping(schema));
            modelBuilder.Configurations.Add(new UserMapping(schema));
            modelBuilder.Configurations.Add(new UserProjectCommentMapping(schema));
            return modelBuilder;
        }
    }
}
