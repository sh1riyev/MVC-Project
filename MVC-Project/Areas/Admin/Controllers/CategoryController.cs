using System;
using System.Reflection.Metadata;
using Fiorello_PB101.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Helpers.Enums;
using MVC_Project.Models;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Category;
using Org.BouncyCastle.Asn1.Ocsp;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        private readonly IWebHostEnvironment _env;
        public CategoryController(ICategoryService service,IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllWithCourseCount());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM reguest)
        {
            if (!ModelState.IsValid) return View();

            bool existCategory = await _service.IsExist(reguest.Name);

            if (existCategory)
            {
                ModelState.AddModelError("Name", "This name is already used");
                return View();
            }
            if (!reguest.Image.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Image", "Input can be only image");
                return View();
            }

            if (!(reguest.Image.Length / 1024 < 200))
            {
                ModelState.AddModelError("Image", "Image size too large");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "-" + reguest.Image.FileName;

            string path = Path.Combine(_env.WebRootPath, "img", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await reguest.Image.CopyToAsync(stream);
            }

            await _service.Create(new Models.Category { Name = reguest.Name,Image=fileName ,ActionBy=User.Identity.Name,CreateDate=DateTime.Now});

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _service.GetById(id);

            if (category is null) return NotFound();

            return View(new CategoryEditVM { Name = category.Name,CurrentImage=category.Image });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CategoryEditVM reguest)
        {
            if (id is null) return BadRequest();

            var category = await _service.GetById(id);

            if (category is null) return NotFound();

            if (!ModelState.IsValid)
            {
                reguest.CurrentImage = category.Image;
                return RedirectToAction(nameof(Index));
            }

            if (reguest.NewImage != null)
            {
                if (!reguest.NewImage.CheckFileSize(500))
                {
                    reguest.CurrentImage = category.Image;
                    ModelState.AddModelError("Images", "Image size must be max 500KB");
                    return View(reguest);
                }
                if (!reguest.NewImage.CheckFileType("image/"))
                {
                    reguest.CurrentImage = category.Image;
                    ModelState.AddModelError("Images", "File type must be only image");
                    return View(reguest);
                }
            }
                var dbCategories = await _service.GetAllCategories();

            if (dbCategories.Any(m => m.Name == reguest.Name && m.Id != category.Id && m.IsDeleted == false))
            {
                reguest.CurrentImage = category.Image;
                ModelState.AddModelError("Name", "Try another,this name is used");
                return View(reguest);
            }

            category.ActionBy = User.Identity.Name;

            await _service.Edit(category, reguest);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _service.GetById(id);

            if (category is null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, "img", category.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            await _service.Delete(category);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _service.GetByIdWithCourse((int)id);

            if (category is null) return NotFound();

            return View(new CategoryDetailVM
            {
                Id = category.Id,
                CategoryName = category.Name,
                CreateDate = category.CreateDate.ToString("dd-mm-yyyy"),
                CourseNames = category.Courses.Where(m => m.CategoryId == id).Select(m => m.Name).ToList(),
                Image = category.Image

            });
        }
    }

}