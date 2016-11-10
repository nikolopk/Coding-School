namespace CF.Models.Database
{
    // User
    public class User
    {
        public int Id { get; set; } // Id (Primary key)
        public string Email { get; set; } // Email (length: 200)
        public string Password { get; set; } // Password (length: 50)
        public string FirstName { get; set; } // FirstName (length: 200)
        public string LastName { get; set; } // LastName (length: 200)
        public string PhotoUrl { get; set; } // PhotoUrl (length: 200)
        public string CardNumber { get; set; } // CardNumber (length: 50)
        public System.DateTime ExpirationDate { get; set; } // ExpirationDate
        public short SecurityCode { get; set; } // SecurityCode
        public System.Guid? VerificationGuid { get; set; } // VerificationGuid
        public bool IsVerified { get; set; } // IsVerified

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<BackerProject> BackerProjects { get; set; } // BackerProject.FK_BackerProject_User
        public virtual System.Collections.Generic.ICollection<Project> Projects { get; set; } // Project.FK_Project_User
        public virtual System.Collections.Generic.ICollection<UserProjectComment> UserProjectComments { get; set; } // UserProjectComment.FK_UserProjectComment_User

        public User()
        {
            BackerProjects = new System.Collections.Generic.List<BackerProject>();
            Projects = new System.Collections.Generic.List<Project>();
            UserProjectComments = new System.Collections.Generic.List<UserProjectComment>();
        }
    }
}
