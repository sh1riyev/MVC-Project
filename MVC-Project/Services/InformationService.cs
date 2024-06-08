using System;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Information;

namespace MVC_Project.Services
{
	public class InformationService :IInformationService
	{
        private readonly AppDbContext _context;

        public InformationService(AppDbContext context)
		{
            _context = context;
		}

        public async Task Create(Information model)
        {
            await _context.Information.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Information model)
        {
             _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<InformationVM>> GetAll()
        {
            var infos = await _context.Information.ToListAsync();

            var infoVM = infos.Select(item => new InformationVM
            {
                Id = item.Id,
                Title = item.Name,
                Description = item.Desciption,
                Image = item.Icon
            }).ToList();

            return infoVM;
        }

        public async Task<Information> GetById(int id)
        {
            return await _context.Information.FindAsync(id);
        }
    }
}

