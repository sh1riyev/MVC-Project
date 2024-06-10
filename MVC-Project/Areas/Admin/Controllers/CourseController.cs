using System;
using Fiorello_PB101.Helpers.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MVC_Project.Models;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Course;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ICourseService _service;
        private readonly ICategoryService _categoryService;
        private readonly IInstructorService _instructorService;
        private readonly IWebHostEnvironment _env;
        public CourseController(ICourseService service,
            ICategoryService categoryService,
            IWebHostEnvironment env,
            IInstructorService instructorServce)
        {
            _service = service;
            _categoryService = categoryService;
            _env = env;
            _instructorService = instructorServce;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await _categoryService.GetAllSelectList();
            ViewBag.instructors = await _instructorService.GetAllSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateVM reguest)
        {
            ViewBag.categories = await _categoryService.GetAllSelectList();
            ViewBag.instructors = await _instructorService.GetAllSelectList();

            if (!ModelState.IsValid)
            {
                return View();
            }

            var existCourse = await _service.IsExist(reguest.Name);

            if (existCourse == true)
            {
                ModelState.AddModelError("CourseName", "This name is used");
                return View();
            }

            foreach (var item in reguest.Images)
            {
                if (!item.CheckFileSize(500))
                {
                    ModelState.AddModelError("NewImage", "Image must be max 500KB");
                    return View();
                }

                if (!item.CheckFileType("image/"))
                {
                    ModelState.AddModelError("NewImage", "Format must be image");
                    return View();
                }
            }

            List<CourseImage> images = new();

            foreach (var item in reguest.Images)
            {
                string fileName = $"{Guid.NewGuid()}-{item.FileName}";
                string path = _env.GenerateFilePath("images", fileName);
                await item.SaveFileToLocalAsync(path);
                images.Add(new CourseImage { Name = fileName });
            }

            Course course = new()
            {
                Name = reguest.Name,
                Rating = reguest.Rating,
                Price = reguest.Price,
                CategoryId = reguest.CategoryId,
                InstructorId=reguest.InstructorId,
                CreateDate=DateTime.Now,
                ActionBy=User.Identity.Name,
                Images = images
            };

            await _service.Create(course);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int ? id)
        {
            if (id is null) return BadRequest();
            var course = await _service.GetById((int)id);
            if (course is null) return NotFound();

            foreach (var item in course.Images)
            {
                string path = Path.Combine(_env.WebRootPath, "img", item.Name);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
    

            await _service.Delete(course);
            return RedirectToAction(nameof(Index));
        }
    }
}
