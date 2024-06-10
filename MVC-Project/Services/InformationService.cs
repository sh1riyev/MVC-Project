using System;
using Fiorello_PB101.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.Services.Interface;
using MVC_Project.ViewModels.Information;
using Org.BouncyCastle.Asn1.Ocsp;

namespace MVC_Project.Services
{
	public class InformationService :IInformationService
	{
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public InformationService(AppDbContext context,IWebHostEnvironment env)
		{
            _context = context;
            _env = env;
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

        public async Task Edit(Information model, InformationEditVM request)
        {
            if (request.NewImage != null)
            {
                string filename = $"{Guid.NewGuid()}-{request.NewImage.FileName}";
                string path = _env.GenerateFilePath("img", filename);
                await request.NewImage.SaveFileToLocalAsync(path);
                model.Icon = filename;
            }
            model.Name = request.Name;
            model.Desciption = request.Description;
            model.UpdateDate = DateTime.Now;
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

