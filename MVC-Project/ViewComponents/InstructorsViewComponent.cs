using System;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.ViewComponents
{
	public class InstructorsViewComponent :ViewComponent
	{
		public InstructorsViewComponent()
		{
		}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

