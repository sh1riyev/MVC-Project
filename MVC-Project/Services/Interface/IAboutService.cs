using System;
using MVC_Project.Models;
using MVC_Project.ViewModels.About;
using MVC_Project.ViewModels.Category;

namespace MVC_Project.Services.Interface
{
	public interface IAboutService
	{
		Task<IEnumerable<AboutVM>> GetAll();
        Task Create(About model);
        Task Delete(About model);
        Task<About> GetById(int id);
        Task<AboutVM> GetFirst();
        Task Edit(About model, AboutEditVM reguest);

    }
}

