using System;
namespace MVC_Project.ViewModels.Information
{
	public class InformationEditVM
	{
		public string ? Name { get; set; }
		public string ? Description { get; set; }
		public string ? CurrentImage { get; set; }
		public IFormFile ? NewImage { get; set; }
	}
}

