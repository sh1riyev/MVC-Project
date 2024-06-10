using System;
namespace MVC_Project.ViewModels.Category
{
	public class CategoryHomeVM
	{
		public int Id { get; set; }
		public string CategoryName { get; set; }
		public string Image { get; set; }
		public int CourseCount { get; set; }
        public string ColumnSizeClass { get; set; }
    }
}

