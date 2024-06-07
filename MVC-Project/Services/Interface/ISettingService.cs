using System;
using MVC_Project.ViewModels.Slider;

namespace MVC_Project.Services.Interface
{
	public interface ISettingService
	{
		public Task<Dictionary<string, string>> GetAllAsync();
	}
}

