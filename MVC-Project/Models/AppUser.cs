using System;
using Microsoft.AspNetCore.Identity;

namespace MVC_Project.Models
{
	public class AppUser :IdentityUser
	{
		public string FullName { get; set; }
	}
}

