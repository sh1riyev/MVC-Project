using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.About;

namespace MVC_Project.Services
{
	public class AboutService : IAboutService
	{
		private readonly AppDbContext _context;
		public AboutService(AppDbContext context)
		{
            _context = context;
		}

        public async Task Create(About model)
        {
            await _context.About.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(About model)
        {
            _context.About.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AboutVM>> GetAll()
        {
            var datas = await _context.About.ToListAsync();

            return datas.Select(item => new AboutVM
            {
                Id=item.Id,
                Title = item.Title,
                Descripntion = item.Description,
                Image = item.Image
            });
        }

        public async Task<About> GetById(int id)
        {
            return await _context.About.FindAsync(id);
        }

        public async Task<AboutVM> GetFirst()
        {
            var data =  await _context.About.FirstOrDefaultAsync(m=>m.IsDeleted==false);

            return new AboutVM { Id = data.Id, Title = data.Title, Descripntion = data.Description, Image = data.Image };
        }
    }
}

