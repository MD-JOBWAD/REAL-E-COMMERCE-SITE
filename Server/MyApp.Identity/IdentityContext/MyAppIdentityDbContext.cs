using MyApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Identity
{
    public class MyAppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyAppIdentityDbContext(DbContextOptions<MyAppIdentityDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ROLE_ID = ADMIN_ID;
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole{
                                Id = ROLE_ID,
                                Name = "Administrator",
                                NormalizedName = "Administrator"
                                },
                new IdentityRole
                                {
                                  Id = "a28be9c0-aa65-4af8-bd17-00bd9344e575",
                                  Name = "Merchant",
                                  NormalizedName = "Merchant"
                },
                new IdentityRole
                                {
                                  Id = "a38be9c0-aa65-4af8-bd17-00bd9344e575",
                                  Name = "General",
                                  NormalizedName = "General"
                }
                );

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin@test.com",
                NormalizedUserName = "admin@test.com",
                Email = "admin@test.com",
                NormalizedEmail = "admin@test.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "@Test123"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

        }

        }//c
}//ns
