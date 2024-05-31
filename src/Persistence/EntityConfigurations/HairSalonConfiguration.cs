using Domain.Entities.Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class HairSalonConfiguration : IEntityTypeConfiguration<HairSalon>
    {
        public void Configure(EntityTypeBuilder<HairSalon> builder)
        {
            builder.ToTable("HairSalons").HasKey(h => h.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

            builder.HasMany(b => b.HairDressers);
            builder.HasMany(b => b.Services);
            builder.HasMany(b => b.HairSalonComments);
            builder.HasMany(b => b.HairSalonHygieneRatings);
            builder.HasMany(b => b.Images);
            

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);  //Default 
        }
    }
}
