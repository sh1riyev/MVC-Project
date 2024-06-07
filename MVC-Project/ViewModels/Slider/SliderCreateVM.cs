using System;
namespace MVC_Project.ViewModels.Slider
{
	public class SliderCreateVM
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public IFormFile Image { get; set; }
	}
}

