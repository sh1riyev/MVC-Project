using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Helpers.Enums;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Information;
using MVC_Project.ViewModels.Setting;
using MVC_Project.ViewModels.Social;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialController : Controller
    {
        private readonly ISocialService _service;
        public SocialController(ISocialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var social = await _service.GetById((int)id);

            if (social is null) return NotFound();

            var socialVM = new SocialEditVM
            {
                Name = social.Name,
                Icon = social.Image
            };
            return View(socialVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SocialEditVM request)
        {
            if (id is null) return BadRequest();

            var social = await _service.GetById((int)id);

            if (social is null) return NotFound();

            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));

            social.ActionBy = User.Identity.Name;

            await _service.Edit(social, request);

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var information = await _service.GetById((int)id);
            if (information is null) return NotFound();

            await _service.Delete(information);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SocialCreateVM request)
        {
            if (!ModelState.IsValid) return View();
            var socials = await _service.GetAll();

            if (socials.Any(m => m.Name == request.Name))
            {
                ModelState.AddModelError("Name", "Social already exist");
                return View();
            }
           await _service.Create(new Models.Social { Name=request.Name,Image=request.Icon,ActionBy=User.Identity.Name,CreateDate=DateTime.Now});
            return RedirectToAction(nameof(Index));
        }
    }
}
