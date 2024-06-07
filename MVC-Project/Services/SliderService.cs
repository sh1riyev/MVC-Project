using System;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Slider;

namespace MVC_Project.Services
{
	public class SliderService :ISliderService
	{
		private readonly AppDbContext _context;
		public SliderService(AppDbContext context)
		{
			_context = context;
		}

        public async Task Create(Slider slider)
        {
            await _context.Sliders.AddAsync(slider);
            await  _context.SaveChangesAsync();
        }

        public async Task Delete(Slider slider)
        {
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SliderVM>> GetAll()
        {
            var sliders = await _context.Sliders.ToListAsync();
            var sliderHomeVM = sliders.Select(item => new SliderVM
            {
                Id=item.Id,
                Description = item.Description,
                Title = item.Title,
                Image = item.Image
            }).ToList();

            return sliderHomeVM;

        }

        public async Task<Slider> GetById(int id)
        {
            return await _context.Sliders.FindAsync(id);
        }
    }
}

