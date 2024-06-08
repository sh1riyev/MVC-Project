using System;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Information;

namespace MVC_Project.ViewComponents
{
	public class InformationViewComponent : ViewComponent
	{
        private readonly IInformationService _infoService;
		public InformationViewComponent(IInformationService infoService)
		{
            _infoService = infoService;
		}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var information = await _infoService.GetAll();
            return await Task.FromResult(View(information));
        }
    }
}

