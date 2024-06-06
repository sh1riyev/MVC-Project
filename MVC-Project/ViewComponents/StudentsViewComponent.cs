using System;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.ViewComponents
{
	public class StudentsViewComponent :ViewComponent
	{
		public StudentsViewComponent()
		{
		}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

