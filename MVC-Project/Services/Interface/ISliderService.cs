using System;
using MVC_Project.Models;
using MVC_Project.ViewModels.Slider;

namespace MVC_Project.Services.Interface
{
	public interface ISliderService
	{
		public Task<IEnumerable<SliderHomeVM>> GetAll();
        public Task Create(Slider slidr);
    }
}

