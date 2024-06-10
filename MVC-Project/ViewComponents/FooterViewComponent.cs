using System;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Services.Interface;

namespace MVC_Project.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISettingService _settingService;
        public FooterViewComponent(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            {
                var settings = await _settingService.GetAllAsync();

                return await Task.FromResult(View(new FooterVM { Settings = settings }));
            }
        }

    }
    public class FooterVM
    {
        public Dictionary<string, string> Settings { get; set; }
    }
}

