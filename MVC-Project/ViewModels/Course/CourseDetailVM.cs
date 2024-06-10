using System;
namespace MVC_Project.ViewModels.Course
{
	public class CourseDetailVM
	{
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Duration { get; set; }
        public int Rating { get; set; }
        public string Category { get; set; }
        public string Instructor { get; set; }
        public int StudentCount { get; set; }
        public List<string> Images { get; set; }
    }
}

