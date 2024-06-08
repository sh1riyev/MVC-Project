using System;
using System.Reflection.Metadata;
using Fiorello_PB101.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MVC_Project.Data;
using MVC_Project.Helpers.Enums;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Slider;

namespace MVC_Project.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SliderController : Controller
	{
        private readonly AppDbContext _context;
        private readonly ISliderService _sliderService;
        private readonly IWebHostEnvironment _env;
        public SliderController(ISliderService sliderService,
                                IWebHostEnvironment env,
                                AppDbContext context)
		{
            _sliderService = sliderService;
            _env = env;
            _context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View(await _sliderService.GetAll());
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


            var titles = await _sliderService.GetAll();

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
            await _sliderService.Create(new Models.Slider { Title = request.Title, Description = request.Description, Image = fileName ,CreateDate=DateTime.Now,ActionBy=User.Identity.Name});

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int ? id)
        {
            if (id is null) return BadRequest();
            var blog = await _sliderService.GetById((int)id);
            if (blog is null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, "img", blog.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            await _sliderService.Delete(blog);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();
            var blog = await _sliderService.GetById((int)id);
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
        public async Task<IActionResult> Edit(int? id,SliderEditVM request)
        {
            if (id is null) return BadRequest();
            var slider = await _sliderService.GetById((int)id);
            if (slider is null) return NotFound();

            if (!ModelState.IsValid)
            {
                request.CurrentImage = slider.Image;
                return View(request);
            }
            if (request.Image != null)
            {
                if (!request.Image.CheckFileSize(500))
                {
                    request.CurrentImage = slider.Image;
                    ModelState.AddModelError("Images", "Image size must be max 500KB");
                    return View(request);
                }
                if (!request.Image.CheckFileType("image/"))
                {
                    request.CurrentImage = slider.Image;
                    ModelState.AddModelError("Images", "File type must be only image");
                    return View(request);
                }

            }

            await _sliderService.Edit(slider, request);

            return RedirectToAction(nameof(Index));
        }
    }
}

