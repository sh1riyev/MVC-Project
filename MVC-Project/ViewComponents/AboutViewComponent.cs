using System;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.ViewComponents
{
	public class AboutViewComponent : ViewComponent
	{
		public AboutViewComponent()
		{
		}

        public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}

    }
}

