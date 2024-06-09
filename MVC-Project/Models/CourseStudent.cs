using System;
namespace MVC_Project.Models
{
	public class CourseStudent
	{
		public int Id { get; set; }
		public int CourseId { get; set; }
		public int StudentId { get; set; }
		public Course Course { get; set; } = null;
		public Student Student { get; set; } = null;
	}
}

