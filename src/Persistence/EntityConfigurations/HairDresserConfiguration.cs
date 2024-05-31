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
    public class HairDresserConfiguration:IEntityTypeConfiguration<HairDresser>
    {
        public void Configure(EntityTypeBuilder<HairDresser> builder)
        {
            builder.ToTable("HairDressers").HasKey(h => h.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(b => b.HairSalon);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);  //Default 
        }
    }
}
