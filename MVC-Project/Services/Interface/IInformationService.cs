using System;
using MVC_Project.Models;
using MVC_Project.ViewModels.Information;

namespace MVC_Project.Services.Interface
{
	public interface IInformationService
	{
		Task<IEnumerable<InformationVM>> GetAll();
		Task Create(Information model);
		Task Delete(Information model);
		Task<Information> GetById(int id);
    }
}

