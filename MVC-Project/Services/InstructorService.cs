using System;
using System.Linq;
using Fiorello_PB101.Helpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Instructor;

namespace MVC_Project.Services
{
	public class InstructorService :IInstructorService
	{
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ICourseService _courseService;
		public InstructorService(AppDbContext context,
            IWebHostEnvironment env,
            ICourseService courseService)
		{
            _context = context;
            _env = env;
            _courseService = courseService;
		}

        public async Task<IEnumerable<Instructor>> GetAll()
        {
            return await _context.Instructors.ToListAsync();
        }

        public async Task<IEnumerable<InstructorVM>> GetAllVM()
        {
            var insturctors= await _context.Instructors.ToListAsync();
            return insturctors.Select(m => new InstructorVM
            {
                Id = m.Id,
                Email = m.Email,
                FullName = m.FullName,
                Image = m.Image
            });
        }

        public async Task<SelectList> GetAllSelectList()
        {
            var datas = await _context.Instructors.ToListAsync();
            return new SelectList(datas, "Id", "Name");
        }

        public async Task Create(Instructor model)
        {
            await _context.Instructors.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Instructor instructor)
        {
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Instructor model,InstructorEditVm request)
        {

            if (request.NewImage != null)
            {
                string filename = $"{Guid.NewGuid()}-{request.NewImage.FileName}";
                string path = _env.GenerateFilePath("img", filename);
                await request.NewImage.SaveFileToLocalAsync(path);
                model.Image = filename;
            }
            var courses = await _courseService.GetAllCourse();

            model.Email = request.Email;
            model.FullName = request.FullName;
            model.Subject = request.Subject;
            model.Courses = courses.Where(c => request.CourseIds.Contains(c.Id)).ToList();

            await _context.SaveChangesAsync();
        }

        public async Task<Instructor> GetById(int id)
        {
            return await _context.Instructors.FindAsync(id);
        }

        public async Task<Instructor> GetByIdWithCourses(int id)
        {
            return await _context.Instructors
            .Include(i => i.Courses)
            .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}

