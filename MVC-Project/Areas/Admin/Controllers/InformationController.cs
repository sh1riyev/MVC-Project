using System;
using Fiorello_PB101.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Helpers.Enums;
using MVC_Project.Services;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.About;
using MVC_Project.ViewModels.Information;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InformationController : Controller
    {
        private readonly IInformationService _infoService;
        private readonly IWebHostEnvironment _env;
        public InformationController(IInformationService infoService,
            IWebHostEnvironment env)
        {
            _infoService = infoService;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _infoService.GetAll());
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InformationCreateVM request)
        {
            if (!ModelState.IsValid) return View();


            var titles = await _infoService.GetAll();

            if (titles.Any(m => m.Title == request.Name))
            {
                ModelState.AddModelError("Title", "Title is used");
                return View();
            }

            if (!request.Image.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Image", "Input can be only image");
                return View();
            }

            if (!(request.Image.Length / 1024 < 200))
            {
                ModelState.AddModelError("Image", "Image size too large");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            string path = Path.Combine(_env.WebRootPath, "img", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await request.Image.CopyToAsync(stream);
            }
            await _infoService.Create(new Models.Information { Name = request.Name, Desciption = request.Description, Icon = fileName, CreateDate = DateTime.Now, ActionBy = User.Identity.Name });

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var information = await _infoService.GetById((int)id);
            if (information is null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, "img", information.Icon);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            await _infoService.Delete(information);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();
            var about = await _infoService.GetById((int)id);
            if (about is null) return NotFound();

            var aboutVM = new InformationEditVM
            {
                CurrentImage = about.Icon,
                Name = about.Name,
                Description = about.Desciption
            };

            return View(aboutVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, InformationEditVM request)
        {
            if (id is null) return BadRequest();

            var info = await _infoService.GetById((int)id);

            if (info is null) return NotFound();

            if (!ModelState.IsValid)
            {
                request.CurrentImage = info.Icon;
                return RedirectToAction(nameof(Index));
            }

            if (request.NewImage != null)
            {
                if (!request.NewImage.CheckFileSize(500))
                {
                    request.CurrentImage = info.Icon;
                    ModelState.AddModelError("Images", "Image size must be max 500KB");
                    return View(request);
                }
                if (!request.NewImage.CheckFileType("image/"))
                {
                    request.CurrentImage = info.Icon;
                    ModelState.AddModelError("Images", "File type must be only image");
                    return View(request);
                }
            }

            info.ActionBy = User.Identity.Name;

            await _infoService.Edit(info, request);

            return RedirectToAction(nameof(Index));
        }
    }
}
