using System;
using Fiorello_PB101.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Helpers.Enums;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Instructor;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class InstructorController :Controller
	{
		private readonly IInstructorService _instructorService;
        private readonly IWebHostEnvironment _env;
        private readonly ICourseService _courseService;
        public InstructorController(IInstructorService instructorService,
            IWebHostEnvironment env,
            ICourseService courseService)
		{
			_instructorService = instructorService;
            _env = env;
            _courseService = courseService;
		}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _instructorService.GetAllVM());
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.courses = await _courseService.GetAllSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InstructorEditVm request)
        {
            ViewBag.courses = await _courseService.GetAllSelectList();
            if (!ModelState.IsValid) return View();
            var instructor = await _instructorService.GetAll();

            if (instructor.Any(m => m.Email == request.Email))
            {
                ModelState.AddModelError("Email", "This email is exist");
                return View();
            }

            if (!request.NewImage.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Image", "Input can be only image");
                return View();
            }

            if (!(request.NewImage.Length / 1024 < 200))
            {
                ModelState.AddModelError("Image", "Image size too large");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;

            string path = Path.Combine(_env.WebRootPath, "img", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await request.NewImage.CopyToAsync(stream);
            }
            var courses = await _courseService.GetAllCourse();

            await _instructorService.Create(new Models.Instructor
            {
                FullName = request.FullName,
                Email = request.Email,
                CreateDate = DateTime.Now,
                ActionBy = User.Identity.Name,
                Subject = request.Subject,
                Courses = courses.Where(c => request.CourseId.Contains(c.Id)).ToList()
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.courses = await _courseService.GetAllSelectList();
            if (id is null) return BadRequest();
            var instructor = await _instructorService.GetByIdWithCourses((int)id);
            if (instructor is null) return NotFound();

            var instructorVM = new InstructorEditVm
            {
                Email = instructor.Email,
                FullName = instructor.FullName,
                CurrentImage = instructor.Image,
                Subject = instructor.Subject,
                CourseIds = instructor.Courses.Select(m => m.Id).ToList()
            };
            return View(instructorVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int?id,InstructorEditVm request)
        {
            ViewBag.courses = await _courseService.GetAllSelectList();
            if (id is null) return BadRequest();
            var instructor = await _instructorService.GetByIdWithCourses((int)id);
            if (instructor is null) return NotFound();

            if (!ModelState.IsValid)
            {
                request.CurrentImage = instructor.Image;
                return RedirectToAction(nameof(Index));
            }

            if (request.NewImage != null)
            {
                if (!request.NewImage.CheckFileSize(500))
                {
                    request.CurrentImage = instructor.Image;
                    ModelState.AddModelError("Images", "Image size must be max 500KB");
                    return View(request);
                }
                if (!request.NewImage.CheckFileType("image/"))
                {
                    request.CurrentImage = instructor.Image;
                    ModelState.AddModelError("Images", "File type must be only image");
                    return View(request);
                }
            }
        }
    }
}

