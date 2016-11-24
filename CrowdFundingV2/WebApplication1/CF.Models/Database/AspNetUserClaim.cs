namespace CF.Models.Database
{

    // AspNetUserClaims
    public class AspNetUserClaim
    {
        public int Id { get; set; } // Id (Primary key)
        public string UserId { get; set; } // UserId (length: 128)
        public string ClaimType { get; set; } // ClaimType
        public string ClaimValue { get; set; } // ClaimValue

        // Foreign keys
        public virtual AspNetUser AspNetUser { get; set; } // FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId
    }

}
// </auto-generated>
