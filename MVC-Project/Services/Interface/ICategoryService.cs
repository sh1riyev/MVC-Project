using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Project.Models;
using MVC_Project.ViewModels.Category;

namespace MVC_Project.Services.Interface
{
	public interface ICategoryService
	{
        Task<IEnumerable<CategoryCourseVM>> GetAllWithCourseCount();
        Task Create(Category category);
        Task Delete(Category category);
        Task Edit(Category category, CategoryEditVM reguest);
        Task<Category> GetById(int? id);
        Task<bool> IsExist(string name);
        Task<Category> GetByIdWithCourse(int id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<SelectList> GetAllSelectList();
        Task<IEnumerable<CategoryHomeVM>> GetForHome();

    }
}

