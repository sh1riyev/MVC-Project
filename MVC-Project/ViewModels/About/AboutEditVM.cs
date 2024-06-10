using System;
namespace MVC_Project.ViewModels.About
{
	public class AboutEditVM
	{
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string ? CurrentImage { get; set; }
        public IFormFile? NewImage { get; set; }
    }
}

