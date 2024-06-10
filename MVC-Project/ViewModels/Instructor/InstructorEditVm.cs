using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.ViewModels.Instructor
{
	public class InstructorEditVm
	{
        public string ? FullName { get; set; }
        [EmailAddress]
        public string ? Email { get; set; }
        public string ? Subject { get; set; }
        public List<int> ? CourseIds { get; set; }
        public IFormFile ? NewImage { get; set; }
        public string ? CurrentImage { get; set; }
    }
}

