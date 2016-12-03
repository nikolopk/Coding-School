using CF.Models.Database;

namespace CF.Data.Context
{

    public interface ICrowdFundingContext : System.IDisposable
    {
        System.Data.Entity.DbSet<AspNetRole> AspNetRoles { get; set; } // AspNetRoles
        System.Data.Entity.DbSet<AspNetUser> AspNetUsers { get; set; } // AspNetUsers
        System.Data.Entity.DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } // AspNetUserClaims
        System.Data.Entity.DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } // AspNetUserLogins
        System.Data.Entity.DbSet<BackerProject> BackerProjects { get; set; } // BackerProject
        System.Data.Entity.DbSet<Category> Categories { get; set; } // Category
        System.Data.Entity.DbSet<Project> Projects { get; set; } // Project
        System.Data.Entity.DbSet<ProjectStatu> ProjectStatus { get; set; } // ProjectStatus
        System.Data.Entity.DbSet<ProjectUpdate> ProjectUpdates { get; set; } // ProjectUpdate
        System.Data.Entity.DbSet<Reward> Rewards { get; set; } // Reward
        System.Data.Entity.DbSet<User> Users { get; set; } // User
        System.Data.Entity.DbSet<UserProjectComment> UserProjectComments { get; set; } // UserProjectComment

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
    }

}
// </auto-generated>
