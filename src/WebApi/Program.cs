using Application;
using Application.Features.RolBasedAccessControlFeatures.Users;
using CloudinaryDotNet;
using Domain.Entities.Project;
using Domain.Entities.RolBasedAccessControlEntities;
using IMFrameworkCore;
using Infrastructure;
using Infrastructure.RoleBasedAccessControl.JwtOptionSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Contexts;
using System.Configuration;

namespace WebApi;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddApplicationServices(builder.Configuration);

        builder.Services.AddPersistenceServices(builder.Configuration); //Persistence

        builder.Services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireUppercase = false;
        }).AddEntityFrameworkStores<BaseDbContext>().AddDefaultTokenProviders(); //Identity

        builder.Services.ConfigureOptions<JwtOptionsSetup>(); //Infrastructure

        builder.Services.ConfigureOptions<JwtBearerOptionsSetup>(); //Infrastructure

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer();

        builder.Services.AddAuthorization(); //Authorization

        builder.Services.AddCors(options => //Cors Settings
        {
            options.AddDefaultPolicy(policy =>
            policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed(policy => true));
        }); //Addedd

       

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddDistributedMemoryCache(); //InMemory
        //builder.Services.AddStackExchangeRedisCache(opt=>opt.Configuration="localhost:6379");

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(setup => //Addedd
        {
            var jwtSecuritySheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecuritySheme, Array.Empty<string>() }
                });
        }); //Jwt

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        if (app.Environment.IsProduction())
            app.ConfigureCustomExceptionMiddleware();//My Package

        app.UseCors();
       
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        CreateFirstUserStartup.CreateFirstUser(app);
       

        app.Run();
    }
}
