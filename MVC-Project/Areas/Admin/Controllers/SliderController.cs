using System;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Helpers.Enums;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Slider;

namespace MVC_Project.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SliderController : Controller
	{
        private readonly ISliderService _sliderService;
        private readonly IWebHostEnvironment _env;
        public SliderController(ISliderService sliderService,
                                IWebHostEnvironment env)
		{
            _sliderService = sliderService;
            _env = env;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create()
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
            await _sliderService.Create(new Models.Slider { Title = request.Title, Description = request.Description, Image = fileName ,CreateDate=DateTime.Now});

            return RedirectToAction(nameof(Index));
        }
    }
}

