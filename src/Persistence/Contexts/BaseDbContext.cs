using Domain.Entities.Project;
using Domain.Entities.RolBasedAccessControlEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence.Contexts;

public class BaseDbContext : IdentityDbContext<User, Role, string>
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<HairSalon> HairSalons { get; set; }
    public DbSet<HairDresser> HairDressers { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<HairDresserRating> HairDresserRatings { get; set; }
    public DbSet<ServiceRating> ServiceRatings { get; set; }
    public DbSet<HairSalonComment> HairSalonComments { get; set; }
    public DbSet<HairSalonHygieneRating> HairSalonHygieneRatings { get; set; }
    public DbSet<HairSalonImage> HairSalonImages { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Ignore<IdentityUserLogin<string>>();
        modelBuilder.Ignore<IdentityUserRole<string>>();
        modelBuilder.Ignore<IdentityUserClaim<string>>();
        modelBuilder.Ignore<IdentityUserToken<string>>();
        modelBuilder.Ignore<IdentityRoleClaim<string>>();
        modelBuilder.Ignore<IdentityRole<string>>();

    }
}
