﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVC_Project.ViewModels.Account
{
	public class LogInVM
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}

