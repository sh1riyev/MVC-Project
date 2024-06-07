using System;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Services.Interface;

namespace MVC_Project.ViewComponents
{
	public class CarouselViewComponent :ViewComponent
	{
        private readonly ISliderService _sliderService;
		public CarouselViewComponent(ISliderService sliderService)
		{
            _sliderService = sliderService;
		}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View(await _sliderService.GetAll()));
        }
    }
}

