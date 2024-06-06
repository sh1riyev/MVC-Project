using System;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.ViewComponents
{
	public class InformationViewComponent : ViewComponent
	{
		public InformationViewComponent()
		{
		}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

