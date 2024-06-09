using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Helpers.Enums;
using MVC_Project.Services;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.About;
using MVC_Project.ViewModels.Slider;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IWebHostEnvironment _env;
        public AboutController(IAboutService aboutService,
                               IWebHostEnvironment env)
        {
            _aboutService = aboutService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _aboutService.GetAll());
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM request)
        {
            if (!ModelState.IsValid) return View();


            var titles = await _aboutService.GetAll();

            if (titles.Any(m => m.Title == request.Title))
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
            await _aboutService.Create(new Models.About { Title = request.Title, Description = request.Description, Image = fileName, CreateDate = DateTime.Now, ActionBy = User.Identity.Name });

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var about = await _aboutService.GetById((int)id);
            if (about is null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, "img", about.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            await _aboutService.Delete(about);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();
            var blog = await _aboutService.GetById((int)id);
            if (blog is null) return NotFound();

            var slider = new SliderEditVM
            {
                CurrentImage = blog.Image,
                Title = blog.Title,
                Description = blog.Description
            };

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int?id,AboutEditVM request)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}

