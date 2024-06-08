using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace MVC_Project.Data
{
	public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Information> Information { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "e6321108-f942-4e92-92d7-a882c0b67b1f", Name = "Member", NormalizedName = "MEMBER" },
                new IdentityRole { Id = "48b43127-5350-4a94-b901-742b2c6c98d7", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "b6cdad15-c6ac-4af2-911b-8065ca4477e2", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" }
            );

            // Seed users
            AppUser admin = new AppUser
            {
                Id = "bfd06bcc-5c10-4845-9bd0-905ab14a53f3",
                UserName = "shiriyev23",
                NormalizedUserName = "SHIRIYEV23",
                Email = "shiriyev@gmail.com",
                NormalizedEmail = "SHIRIYEV@GMAIL.COM",
                FullName = "Ilqar Shiriyev",
                EmailConfirmed = true,
                PhoneNumber = "0508802323",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false
            };
            AppUser supperAdmin = new AppUser
            {
                Id = "aebb8b80-e548-419a-bb3a-e9c8b1c92834",
                UserName = "salam23",
                NormalizedUserName = "SALAM23",
                Email = "salam@gmail.com",
                NormalizedEmail = "SALAM@GMAIL.COM",
                FullName = "Ilqar Shiriyev",
                EmailConfirmed = true,
                PhoneNumber = "0508802323",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false
            };
            var hasher = new PasswordHasher<AppUser>();
            admin.PasswordHash= hasher.HashPassword(admin, "Ilqar123.");
            admin.PasswordHash= hasher.HashPassword(supperAdmin, "Ilqar123.");
            builder.Entity<AppUser>().HasData(admin,supperAdmin 
            );

            // Seed user roles
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "aebb8b80-e548-419a-bb3a-e9c8b1c92834", RoleId = "48b43127-5350-4a94-b901-742b2c6c98d7" },
                new IdentityUserRole<string> { UserId = "bfd06bcc-5c10-4845-9bd0-905ab14a53f3", RoleId = "b6cdad15-c6ac-4af2-911b-8065ca4477e2" }
            );

            // Add your other model configurations here
            // Example: builder.Entity<YourModel>().HasData(...);
        }
    }
}

