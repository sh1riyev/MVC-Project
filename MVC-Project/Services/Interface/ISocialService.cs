using System;
using MVC_Project.Models;
using MVC_Project.ViewModels.Social;

namespace MVC_Project.Services.Interface
{
	public interface ISocialService
	{
		Task<IEnumerable<SocialVM>> GetAll();
        Task Edit(Social model, SocialEditVM request);
        Task Create(Social model);
		Task Delete(Social model);
		Task<Social> GetById(int id);
	}
}

