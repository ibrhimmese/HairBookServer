using Domain.Entities.Project;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityConfigurations;

public class HairSalonCommentConfiguration : IEntityTypeConfiguration<HairSalonComment>
{
    public void Configure(EntityTypeBuilder<HairSalonComment> builder)
    {
        builder.ToTable("HairSalonComments").HasKey(h => h.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.HairSalon);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);  //Default 
    }
}
