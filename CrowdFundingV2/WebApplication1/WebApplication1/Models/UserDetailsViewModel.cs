using CF.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserDetailsViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } // UserName (length: 256)
        public string FirstName { get; set; } // FirstName
        public string LastName { get; set; } // LastName
        public string PhotoUrl { get; set; } // PhotoUrl (length: 200)
        public string AspNetUsersId { get; set; } // AspNetUsersId (length: 128)
        public string Email { get; set; } // Email (length: 256)
        public string PhoneNumber { get; set; } // PhoneNumber
    }
}