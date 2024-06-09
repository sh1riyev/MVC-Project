﻿using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Category;

namespace MVC_Project.Services
{
	public class CategoryService :ICategoryService
	{
		private readonly AppDbContext _context;
		public CategoryService(AppDbContext context)
		{
			_context = context;
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
            category.Name = reguest.Name;
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
    }
}

