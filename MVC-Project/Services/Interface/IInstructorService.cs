using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Project.Models;
using MVC_Project.ViewModels.Instructor;

namespace MVC_Project.Services.Interface
{
	public interface IInstructorService
	{
        Task Create(Instructor instructor);
        Task Delete(Instructor instructor);
        Task Edit(Instructor model,InstructorEditVm request);
        Task<SelectList> GetAllSelectList();
        Task<IEnumerable<Instructor>> GetAll();
        Task<IEnumerable<InstructorVM>> GetAllVM();
        Task<Instructor> GetById(int id);
        Task<Instructor> GetByIdWithCourses(int id);
    }
}

