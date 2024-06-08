using System;
namespace MVC_Project.ViewModels.Information
{
	public class InformationCreateVM
	{
		public string Name { get; set; }
		public string  Description { get; set; }
		public IFormFile Image { get; set; }
	}
}

