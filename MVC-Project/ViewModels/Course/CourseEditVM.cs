﻿using System;
namespace MVC_Project.ViewModels.Course
{
	public class CourseEditVM
	{
        public string ?CourseName { get; set; }
        public int ?CategoryId { get; set; }
        public int ?Rating { get; set; }
        public double ?Duration { get; set; }
        public string? Price { get; set; }
        public List<string> ?CurrentImages { get; set; }
        public List<IFormFile> ?NewImage { get; set; }
        public string? Instructor { get; set; }
    }
}
