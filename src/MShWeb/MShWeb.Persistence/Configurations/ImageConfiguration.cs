using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MShWeb.Domain.Entities;

namespace MShWeb.Persistence.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images").HasKey("Id");

            builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
            builder.Property(i => i.Source).HasColumnName("Source");
            builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(i => i.Product);

            builder.HasQueryFilter(i => !i.DeletedDate.HasValue);

        }
    }
}
