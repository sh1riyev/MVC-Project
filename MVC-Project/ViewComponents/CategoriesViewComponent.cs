using System;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Services.Interface;

namespace MVC_Project.ViewComponents
{
	public class CategoriesViewComponent : ViewComponent
	{
        private readonly ICategoryService _serivce;
		public CategoriesViewComponent(ICategoryService service)
		{
            _serivce = service;
		}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _serivce.GetForHome());
        }
    }
}

