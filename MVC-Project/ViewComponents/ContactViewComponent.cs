using System;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.ViewComponents
{
	public class ContactViewComponent : ViewComponent
	{
		public ContactViewComponent()
		{
		}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

