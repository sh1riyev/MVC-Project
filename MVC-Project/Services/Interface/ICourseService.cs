using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Project.Models;
using MVC_Project.ViewModels.Course;

namespace MVC_Project.Services.Interface
{
	public interface ICourseService
	{
        Task<IEnumerable<CourseVM>> GetAll();
        Task<IEnumerable<Course>> GetAllCourse(); 
        Task<bool> IsExist(string name);
        Task Create(Course course);
        Task Delete(Course course);
        Task Edit(Course course, CourseEditVM request);
        Task<Course> GetById(int id);
        Task<SelectList> GetAllSelectList();

    }
}

