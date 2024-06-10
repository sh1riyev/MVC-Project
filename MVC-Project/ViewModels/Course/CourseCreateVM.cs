using System;
namespace MVC_Project.ViewModels.Course
{
	public class CourseCreateVM
	{
		public string Name { get; set; }
        public decimal Price { get; set; }
        public double Duration { get; set; }
        public int Rating { get; set; }
        public int CategoryId { get; set; }
        public int ? InstructorId { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}

