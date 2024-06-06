using System;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.ViewComponents
{
	public class CarouselViewComponent :ViewComponent
	{
		public CarouselViewComponent()
		{
		}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

