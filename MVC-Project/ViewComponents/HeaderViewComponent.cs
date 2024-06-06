﻿using System;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Account;

namespace MVC_Project.ViewComponents
{
	public class HeaderViewComponent :ViewComponent
	{
		private readonly ISettingService _settingService;
		public HeaderViewComponent(ISettingService settingService)
		{
			_settingService = settingService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var settings = await _settingService.GetAllAsync();
		var login = new LogInVM();

            return await Task.FromResult(View(new HeaderVM { Settings=settings,UserLogin=login}));
        }
}


	public class HeaderVM
	{
		public Dictionary<string,string> Settings { get; set; }
		public LogInVM UserLogin { get; set; }
	}
}

