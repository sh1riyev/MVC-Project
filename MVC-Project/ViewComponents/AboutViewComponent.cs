using System;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Services.Interface;

namespace MVC_Project.ViewComponents
{
	public class AboutViewComponent : ViewComponent
	{
		private readonly IAboutService _aboutService;
		public AboutViewComponent(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

        public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(await _aboutService.GetAll());
		}

    }
}

