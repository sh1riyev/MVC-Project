using System;
namespace MVC_Project.Models
{
	public class Student :BaseEntity
	{
		public string FullName { get; set; }
		public string Profession { get; set; }
		public string About { get; set; }
	}
}

