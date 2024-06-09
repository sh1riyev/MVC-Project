using System;
namespace MVC_Project.ViewModels.Category
{
	public class CategoryDetailVM
	{
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CreateDate { get; set; }
        public List<string> CourseNames { get; set; }
        public List<CategoryCourseImageVM> Images { get; set; }
    }
}

