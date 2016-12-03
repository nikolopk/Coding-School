namespace CF.Models.Database
{

    // User
    public class User
    {
        public int Id { get; set; } // Id (Primary key)
        public string PhotoUrl { get; set; } // PhotoUrl
        public byte[] Image { get; set; } // Image

        public string AspNetUsersId { get; set; } // AspNetUsersId (length: 128)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<BackerProject> BackerProjects { get; set; } // BackerProject.FK_BackerProject_User
        public virtual System.Collections.Generic.ICollection<Project> Projects { get; set; } // Project.FK_Project_User
        public virtual System.Collections.Generic.ICollection<UserProjectComment> UserProjectComments { get; set; } // UserProjectComment.FK_UserProjectComment_User

        // Foreign keys
        public virtual AspNetUser AspNetUser { get; set; } // FK_User_AspNetUsers

        public User()
        {
            BackerProjects = new System.Collections.Generic.List<BackerProject>();
            Projects = new System.Collections.Generic.List<Project>();
            UserProjectComments = new System.Collections.Generic.List<UserProjectComment>();
        }
    }

}
// </auto-generated>
