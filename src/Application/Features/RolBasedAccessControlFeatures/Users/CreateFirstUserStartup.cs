using Application.Services.Repositories.RolBasedAccessControlRepositories.Repositories;
using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using Domain.Entities.RolBasedAccessControlEntities;
using IMFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RolBasedAccessControlFeatures.Users;

public static class CreateFirstUserStartup
{
    public static void CreateFirstUser(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scoped.ServiceProvider.GetRequiredService<RoleManager<Role>>();
            var userRoleManager = scoped.ServiceProvider.GetRequiredService<IUserRoleRepository>();



            if (!userManager.Users.Any(p => p.UserName == "admin") && !roleManager.Roles.Any(p => p.Name == "Admin"))
            {
                

                User user = new()
                {
                    Id=Guid.NewGuid().ToString(),
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = "İbrahim",
                    LastName = "Meşe",
                    EmailConfirmed = true,
                };
                Role role = new()
                {
                    Name = "Admin",
                    Id = Guid.NewGuid().ToString(),
                };
                UserRole userRole = new()
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    RoleId = role.Id,

                };

                string password = "Admin.1";
                userManager.CreateAsync(user, password).Wait();
                roleManager.CreateAsync(role).Wait();
                userRoleManager.AddAsync(userRole).Wait();

            }
        }
    }
}
