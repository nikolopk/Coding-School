using System.ComponentModel.DataAnnotations;

namespace CF.Models.MVC.Account
{
    public class ExternalLoginConfirmationViewModel : ICachableModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
