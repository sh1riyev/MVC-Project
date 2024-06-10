using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.ViewModels.Category
{
	public class CategoryEditVM
	{
        [Required(ErrorMessage = "This input cannot be empty")]
        [StringLength(15)]
        public string ? Name { get; set; }
        public string? CurrentImage { get; set; }
        public IFormFile ? NewImage { get; set; }
    }
}

