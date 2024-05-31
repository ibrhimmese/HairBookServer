using Application.Services.Repositories.ProjectRepositories;
using Application.Services.Repositories.RolBasedAccessControlRepositories.Repositories;
using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.ProjectRepositories;
using Persistence.Repositories.RolBasedAccessControlRepositories.Repositories;
using Persistence.Repositories.RolBasedAccessControlRepositories.Services;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("StartupProject")));
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserRoleService, UserRoleService>();

        services.AddScoped<IHairSalonRepository, HairSalonRepository>();
        services.AddScoped<IHairDresserRepository, HairDresserRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IHairDresserRatingRepository, HairDresserRatingRepository>();
        services.AddScoped<IServiceRatingRepository, ServiceRatingRepository>();
        services.AddScoped<IHairSalonCommentRepository, HairSalonCommentRepository>();
        services.AddScoped<IHairSalonHygieneRatingRepository, HairSalonHygieneRatingRepository>();
        services.AddScoped<IHairSalonImageRepository, HairSalonImageRepository>();

        return services;
    }
}

