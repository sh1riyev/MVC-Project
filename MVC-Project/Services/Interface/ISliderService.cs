using System;
using MVC_Project.Models;
using MVC_Project.ViewModels.Slider;

namespace MVC_Project.Services.Interface
{
	public interface ISliderService
	{
		public Task<IEnumerable<SliderVM>> GetAll();
        public Task Create(Slider slidr);
        public Task Delete(Slider slider);
        public Task<Slider> GetById(int id);
        public Task Edit(Slider slider, SliderEditVM editSlider);
    }
}

