using CF.Data2.Mappings;
using CF.Models.Database;
using System.Data.Entity;

namespace CF.Data2.Context
{
    //https://blog.longle.net/2013/10/09/upgrading-to-async-with-entity-framework-mvc-odata-asyncentitysetcontroller-kendo-ui-glimpse-generic-unit-of-work-repository-framework-v2-0/
    //https://genericunitofworkandrepositories.codeplex.com/
    public class CrowdFundingDbContext : System.Data.Entity.DbContext, IDbContext
    {
        static CrowdFundingDbContext()
        {
            System.Data.Entity.Database.SetInitializer<CrowdFundingDbContext>(null);
        }

        public CrowdFundingDbContext()
            : base("Name=CrowdFunding")
        {
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            this.ApplyStateChanges();
            return base.SaveChanges();
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
