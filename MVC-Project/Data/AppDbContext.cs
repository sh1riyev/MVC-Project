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
        public DbSet<About> About { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Social> Socials { get; set; }

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

            builder.Entity<Setting>().HasData(
                new Setting { Id=1,Key = "Logo", Value = "fa fa-book me-3" },
                new Setting { Id=2,Key = "Navbar-Name", Value = "eLEARNING" },
                new Setting { Id = 3, Key = "Address", Value = "123 Street, New York, USA" },
                new Setting { Id = 4, Key = "Phone", Value = "+012 345 67890" },
                new Setting { Id = 5, Key = "Email", Value = "info@example.com" },
                new Setting { Id = 6, Key = "Twitter", Value = "https://x.com/home" },
                new Setting { Id = 7, Key = "Facebook", Value = "https://facebook.com/home" },
                new Setting { Id = 8, Key = "Youtube", Value = "https://youtube.com/home" },
                new Setting { Id = 9, Key = "Linkedin", Value = "https://linkedin.com/home" }
                );

            builder.Entity<Social>().HasData(
               new Social { Id = 1, Name = "Facebook", Image = "fab fa-facebook-f" },
               new Social { Id = 2, Name = "Twitter", Image = "fab fa-twitter" },
               new Social { Id = 3, Name = "Instagram", Image = "fab fa-instagram" }
                );
        }
    }
}

