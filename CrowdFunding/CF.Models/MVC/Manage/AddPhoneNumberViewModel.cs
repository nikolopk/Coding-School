using System.ComponentModel.DataAnnotations;

namespace CF.Models.MVC.Manage
{
    public class AddPhoneNumberViewModel : ICachableModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}
