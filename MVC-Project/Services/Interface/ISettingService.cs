using System;
using MVC_Project.Models;
using MVC_Project.ViewModels.Information;
using MVC_Project.ViewModels.Setting;

namespace MVC_Project.Services.Interface
{
	public interface ISettingService
	{
		public Task<Dictionary<string, string>> GetAllAsync();
		Task<Setting> GetById(int id);
        Task Edit(Setting model, SettingEditVM request);
		Task<IEnumerable<SettingVM>> GetAll();

    }
}

