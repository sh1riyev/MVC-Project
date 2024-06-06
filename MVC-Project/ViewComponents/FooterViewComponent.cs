using System;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.ViewComponents
{
    public class FooterViewComponent : ViewComponent
	{
		public FooterViewComponent()
		{
		}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

