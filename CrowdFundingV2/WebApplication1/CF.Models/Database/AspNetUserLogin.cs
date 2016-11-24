namespace CF.Models.Database
{

    // AspNetUserLogins
    public class AspNetUserLogin
    {
        public string LoginProvider { get; set; } // LoginProvider (Primary key) (length: 128)
        public string ProviderKey { get; set; } // ProviderKey (Primary key) (length: 128)
        public string UserId { get; set; } // UserId (Primary key) (length: 128)

        // Foreign keys
        public virtual AspNetUser AspNetUser { get; set; } // FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId
    }

}
// </auto-generated>
