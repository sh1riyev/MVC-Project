using System;
namespace MVC_Project.Models
{
	public class Course : BaseEntity
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public double Duration { get; set; }
		public int Rating { get; set; }
		public ICollection<CourseImage> Images { get; set; }
		public List<CourseStudent> CourseStudents { get; set; }
		public int InstructorId { get; set; }
		public Instructor Instructor { get; set; }
	}
}

