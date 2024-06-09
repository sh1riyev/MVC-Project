using System;
namespace MVC_Project.Models
{
	public class Social :BaseEntity
	{
		public string Name { get; set; }
		public List<InstructorSocial> InstructorSocials { get; set; }
	}
}

