using System;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Setting;

namespace MVC_Project.Services
{
	public class SettingService: ISettingService
	{
        private readonly AppDbContext _context;
		public SettingService(AppDbContext context)
		{
            _context = context;
		}

        public async Task Edit(Setting model, SettingEditVM request)
        {
            model.Value = request.Value;
           await _context.SaveChangesAsync();
        }
        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            return await _context.Settings.ToDictionaryAsync(m => m.Key, m => m.Value);
        }

        public async Task<IEnumerable<SettingVM>> GetAll()
        {
            var settings= await _context.Settings.ToListAsync();

            return settings.Select(item => new SettingVM
            {
                Id = item.Id,
                Key = item.Key,
                Value = item.Value

            });
        }

        public async Task<Setting> GetById(int id)
        {
            return await _context.Settings.FindAsync(id);
        }
    }
}

