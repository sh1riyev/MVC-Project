using System;
using Fiorello_PB101.Helpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Category;
using MVC_Project.ViewModels.Slider;

namespace MVC_Project.Services
{
	public class CategoryService :ICategoryService
	{
		private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
		public CategoryService(AppDbContext context,
            IWebHostEnvironment env)
		{
			_context = context;
            _env = env;
		}

        public async Task Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }


        public async Task Edit(Category category, CategoryEditVM reguest)
        {
            if (reguest.NewImage != null)
            {
                string filename = $"{Guid.NewGuid()}-{reguest.NewImage.FileName}";
                string path = _env.GenerateFilePath("img", filename);
                await reguest.NewImage.SaveFileToLocalAsync(path);
                category.Image = filename;
            }
            category.Name = reguest.Name;
            category.UpdateDate = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<CategoryCourseVM>> GetAllWithCourseCount()
        {
            IEnumerable<Category> categories = await _context.Categories.Include(m => m.Courses).ToListAsync();

            return categories.Select(m => new CategoryCourseVM
            {
                Id = m.Id,
                CategoryName = m.Name,
                CreateDate = m.CreateDate.ToString("dd-mm-yyyy"),
                CourseCount = m.Courses.Count()
            });
        }

        public async Task<Category> GetById(int? id)
        {
            return await _context.Categories.FirstOrDefaultAsync(m => m.Id == (int)id);
        }

        public async Task<bool> IsExist(string name)
        {
            return await _context.Categories.AnyAsync(m => m.Name == name);
        }

        public async Task<Category> GetByIdWithCourse(int id)
        {
            var category = await _context.Categories.Include(m => m.Courses).FirstOrDefaultAsync(m => m.Id == id);

            return category;
        }

        public async Task<SelectList> GetAllSelectList()
        {
            var datas = await _context.Categories.ToListAsync();
            return new SelectList(datas, "Id", "Name");
        }

        public async Task<IEnumerable<CategoryHomeVM>> GetForHome()
        {
            var categories = await _context.Categories.Include(m => m.Courses).ToListAsync();

            return categories.Select(m => new CategoryHomeVM
            {
                Id=m.Id,
                CategoryName = m.Name,
                Image = m.Image,
                CourseCount = m.Courses.Count()
            });
        }
    }
}

