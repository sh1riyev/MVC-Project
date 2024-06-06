using System;
namespace MVC_Project.Models
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public bool IsDeleted { get; set; } = false;
		public DateTime CreateDate { get; set; } = DateTime.Now;
		public DateTime ? UpdateDate { get; set; }
		public DateTime ? DeleteDate { get; set; }
		public string ActionBy { get; set; }
	}
}

