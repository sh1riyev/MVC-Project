using System;
namespace MVC_Project.Models
{
	public class Instructor : BaseEntity
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public ICollection<Course> Courses { get; set; }
		public List<InstructorSocial> InstructorSocials { get; set; }
	}
}

