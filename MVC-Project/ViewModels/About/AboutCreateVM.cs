using System;
namespace MVC_Project.ViewModels.About
{
	public class AboutCreateVM
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}

