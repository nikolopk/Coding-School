namespace CF.Models.Database
{

    // AspNetRoles
    public class AspNetRole
    {
        public string Id { get; set; } // Id (Primary key) (length: 128)
        public string Name { get; set; } // Name (length: 256)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<AspNetUser> AspNetUsers { get; set; } // Many to many mapping

        public AspNetRole()
        {
            AspNetUsers = new System.Collections.Generic.List<AspNetUser>();
        }
    }

}
// </auto-generated>
