using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Helpers.Enums;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Setting;
using Org.BouncyCastle.Asn1.Ocsp;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingController : Controller
	{
        private readonly ISettingService _service;
		public SettingController(ISettingService service)
		{
            _service = service;
		}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int ? id)
        {
            if (id is null) return BadRequest();

            var setting = await _service.GetById((int)id);

            if (setting is null) return NotFound();

            var settingVM = new SettingEditVM
            {
                Key = setting.Key,
                Value = setting.Value
            };
            return View(settingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int?id,SettingEditVM request)
        {
            if (id is null) return BadRequest();

            var setting = await _service.GetById((int)id);

            if (setting is null) return NotFound();

            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));

            setting.ActionBy = User.Identity.Name;

            await _service.Edit(setting, request);

            return RedirectToAction(nameof(Index));

        }
    }
}

