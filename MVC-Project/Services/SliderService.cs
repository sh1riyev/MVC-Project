using System;
using Fiorello_PB101.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Slider;
using Org.BouncyCastle.Asn1.Ocsp;

namespace MVC_Project.Services
{
	public class SliderService :ISliderService
	{
		private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
		public SliderService(AppDbContext context,
                            IWebHostEnvironment env)
		{
			_context = context;
            _env = env;
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

        public async Task Edit(Slider slider, SliderEditVM editSlider)
        {
            if (editSlider.Image != null)
            {
                string filename = $"{Guid.NewGuid()}-{editSlider.Image.FileName}";
                string path = _env.GenerateFilePath("img", filename);
                await editSlider.Image.SaveFileToLocalAsync(path);
                slider.Image = filename;
            }

            slider.Title = editSlider.Title;
            slider.Description = editSlider.Description;
            slider.UpdateDate = DateTime.Now;

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

