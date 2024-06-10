using System;
using MVC_Project.Models;

namespace MVC_Project.ViewModels.Instructor
{
	public class InstructorCreateVM
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public List<int> CourseId { get; set; }
		public IFormFile NewImage { get; set; }
    }
}

