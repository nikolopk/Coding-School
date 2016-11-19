using System;

namespace CF.Models.MVC.Account
{
    public class ExternalLoginListViewModel : ICachableModel
    {
        public string ReturnUrl { get; set; }
    }
}
