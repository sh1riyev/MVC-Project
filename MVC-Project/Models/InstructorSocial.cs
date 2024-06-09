using System;
namespace MVC_Project.Models
{
	public class InstructorSocial
	{
		public int Id { get; set; }
		public int InstructorId { get; set; }
		public int SocialId { get; set; }
        public string Url { get; set; }
        public Instructor Instructor { get; set; } = null;
		public Social Social { get; set; } = null;
	}
}

