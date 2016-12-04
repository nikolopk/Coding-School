using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class UserDetailsViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string PhotoUrl { get; set; } 
        public string Email { get; set; } 
        public string PhoneNumber { get; set; }

        public IEnumerable<BasicProjectInfoViewModel> MyProjects { get; set; }
        public IEnumerable<BasicProjectInfoViewModel> BackProjects { get; set; }
    }
}