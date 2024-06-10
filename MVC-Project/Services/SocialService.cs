using System;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Social;

namespace MVC_Project.Services
{
	public class SocialService : ISocialService
	{
        private readonly AppDbContext _context;
		public SocialService(AppDbContext context)
		{
            _context = context;
		}

        public async Task Create(Social model)
        {
            await _context.Socials.AddAsync(model);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(Social model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Social model, SocialEditVM request)
        {
            model.Image = request.Icon;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SocialVM>> GetAll()
        {
            var socials = await _context.Socials.ToListAsync();

            var socialVM = socials.Select(m => new SocialVM
            {
                Id = m.Id,
                Name = m.Name,
                Icon = m.Image
            });

            return socialVM;
        }

        public async Task<Social> GetById(int id)
        {
            return await _context.Socials.FindAsync(id);
        }
    }
}

