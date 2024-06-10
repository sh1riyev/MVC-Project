using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Course;

namespace MVC_Project.Services
{
	public class CourseService :ICourseService
	{
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public Task Edit(Course course, CourseEditVM request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CourseVM>> GetAll()
        {
            IEnumerable<Course> courses = await _context.Courses.Include(m => m.Category).Include(m => m.Images).ToListAsync();

            return courses.Select(m => new CourseVM
            {
                Id = m.Id,
                CourseName = m.Name,
                CategoryName = m.Category?.Name,
                Price = m.Price,
                MainImage = m.Images.FirstOrDefault(m => m.IsMain == true)?.ToString()
            });
        }

        public async Task<IEnumerable<Course>> GetAllCourse()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<SelectList> GetAllSelectList()
        {
            var datas = await _context.Courses.ToListAsync();
            return new SelectList(datas, "Id", "Name");
        }

        public async Task<Course> GetById(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<Course> GetByIdWithImage(int id)
        {
            return await _context.Courses.Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> IsExist(string name)
        {
            return await _context.Courses.AnyAsync(m => m.Name == name && m.IsDeleted == true);
        }
    }
}

