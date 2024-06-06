using System;
namespace MVC_Project.Services.Interface
{
	public interface ISettingService
	{
		public Task<Dictionary<string, string>> GetAllAsync();
	}
}

