using System;
using System.Data;
using Fiorello_PB101.Helpers.Extensions;
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
        private readonly IWebHostEnvironment _env;
		public AboutService(AppDbContext context,
            IWebHostEnvironment env)
		{
            _context = context;
            _env = env;
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

        public async Task Edit(About model, AboutEditVM reguest)
        {
            if (reguest.NewImage != null)
            {
                string filename = $"{Guid.NewGuid()}-{reguest.NewImage.FileName}";
                string path = _env.GenerateFilePath("img", filename);
                await reguest.NewImage.SaveFileToLocalAsync(path);
                model.Image = filename;
            }
            model.Title = reguest.Title;
            model.Description = reguest.Description;
            model.UpdateDate = DateTime.Now;
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

