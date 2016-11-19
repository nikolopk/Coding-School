using System.Collections.Generic;

namespace CF.Models.MVC.Manage
{
    public class ConfigureTwoFactorViewModel : ICachableModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}