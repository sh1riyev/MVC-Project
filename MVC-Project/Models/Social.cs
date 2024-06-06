using System;
namespace MVC_Project.Models
{
	public class Social
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public List<InstructorSocial> InstructorSocials { get; set; }
	}
}

