﻿using System;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.Services.Interface;

namespace MVC_Project.Services
{
	public class SettingService: ISettingService
	{
        private readonly AppDbContext _context;
		public SettingService(AppDbContext context)
		{
            _context = context;
		}

        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            return await _context.Settings.ToDictionaryAsync(m => m.Key, m => m.Value);
        }
    }
}

