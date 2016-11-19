﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CF.Models.MVC.Account
{
    public class ForgotPasswordViewModel : ICachableModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}