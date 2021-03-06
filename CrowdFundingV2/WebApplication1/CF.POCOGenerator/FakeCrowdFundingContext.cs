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

    using System.Linq;

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class FakeCrowdFundingContext : ICrowdFundingContext
    {
        public System.Data.Entity.DbSet<AspNetRole> AspNetRoles { get; set; }
        public System.Data.Entity.DbSet<AspNetUser> AspNetUsers { get; set; }
        public System.Data.Entity.DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public System.Data.Entity.DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public System.Data.Entity.DbSet<BackerProject> BackerProjects { get; set; }
        public System.Data.Entity.DbSet<Category> Categories { get; set; }
        public System.Data.Entity.DbSet<Project> Projects { get; set; }
        public System.Data.Entity.DbSet<ProjectStatu> ProjectStatus { get; set; }
        public System.Data.Entity.DbSet<ProjectUpdate> ProjectUpdates { get; set; }
        public System.Data.Entity.DbSet<Reward> Rewards { get; set; }
        public System.Data.Entity.DbSet<sys_DatabaseFirewallRule> sys_DatabaseFirewallRules { get; set; }
        public System.Data.Entity.DbSet<Sysdiagram> Sysdiagrams { get; set; }
        public System.Data.Entity.DbSet<User> Users { get; set; }
        public System.Data.Entity.DbSet<UserProjectComment> UserProjectComments { get; set; }

        public FakeCrowdFundingContext()
        {
            AspNetRoles = new FakeDbSet<AspNetRole>("Id");
            AspNetUsers = new FakeDbSet<AspNetUser>("Id");
            AspNetUserClaims = new FakeDbSet<AspNetUserClaim>("Id");
            AspNetUserLogins = new FakeDbSet<AspNetUserLogin>("LoginProvider", "ProviderKey", "UserId");
            BackerProjects = new FakeDbSet<BackerProject>("Id");
            Categories = new FakeDbSet<Category>("Id");
            Projects = new FakeDbSet<Project>("Id");
            ProjectStatus = new FakeDbSet<ProjectStatu>("Id");
            ProjectUpdates = new FakeDbSet<ProjectUpdate>("Id");
            Rewards = new FakeDbSet<Reward>("Id");
            sys_DatabaseFirewallRules = new FakeDbSet<sys_DatabaseFirewallRule>("Id", "Name", "StartIpAddress", "EndIpAddress", "CreateDate", "ModifyDate");
            Sysdiagrams = new FakeDbSet<Sysdiagram>("DiagramId");
            Users = new FakeDbSet<User>("Id");
            UserProjectComments = new FakeDbSet<UserProjectComment>("Id");
        }

        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1);
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }

        // Stored Procedures
        public int SpAlterdiagram(string diagramname, int? ownerId, int? version, byte[] definition)
        {
 
            return 0;
        }

        public int SpCreatediagram(string diagramname, int? ownerId, int? version, byte[] definition)
        {
 
            return 0;
        }

        public int SpDropdiagram(string diagramname, int? ownerId)
        {
 
            return 0;
        }

        public System.Collections.Generic.List<SpHelpdiagramdefinitionReturnModel> SpHelpdiagramdefinition(string diagramname, int? ownerId)
        {
            int procResult;
            return SpHelpdiagramdefinition(diagramname, ownerId, out procResult);
        }

        public System.Collections.Generic.List<SpHelpdiagramdefinitionReturnModel> SpHelpdiagramdefinition(string diagramname, int? ownerId, out int procResult)
        {

            procResult = 0;
            return new System.Collections.Generic.List<SpHelpdiagramdefinitionReturnModel>();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<SpHelpdiagramdefinitionReturnModel>> SpHelpdiagramdefinitionAsync(string diagramname, int? ownerId)
        {
            int procResult;
            return System.Threading.Tasks.Task.FromResult(SpHelpdiagramdefinition(diagramname, ownerId, out procResult));
        }

        public System.Collections.Generic.List<SpHelpdiagramsReturnModel> SpHelpdiagrams(string diagramname, int? ownerId)
        {
            int procResult;
            return SpHelpdiagrams(diagramname, ownerId, out procResult);
        }

        public System.Collections.Generic.List<SpHelpdiagramsReturnModel> SpHelpdiagrams(string diagramname, int? ownerId, out int procResult)
        {

            procResult = 0;
            return new System.Collections.Generic.List<SpHelpdiagramsReturnModel>();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<SpHelpdiagramsReturnModel>> SpHelpdiagramsAsync(string diagramname, int? ownerId)
        {
            int procResult;
            return System.Threading.Tasks.Task.FromResult(SpHelpdiagrams(diagramname, ownerId, out procResult));
        }

        public int SpRenamediagram(string diagramname, int? ownerId, string newDiagramname)
        {
 
            return 0;
        }

        public int SpUpgraddiagrams()
        {
 
            return 0;
        }

    }
}
// </auto-generated>
