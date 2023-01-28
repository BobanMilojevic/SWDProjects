using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Swd.PlayCollector.Model;

public class CollectionItemConfig : IEntityTypeConfiguration<CollectionItem>
{
    public void Configure(EntityTypeBuilder<CollectionItem> entity)
    {
        entity.HasKey(m => m.Id).IsClustered(true);
        entity.Property(m => m.Name).IsRequired().HasColumnType("nvarchar(50)").HasComment("Name of collection item");
        entity.Property(m => m.Number).IsRequired().HasColumnType("nvarchar(25)").HasComment("Number of collection item");
        entity.Property(m => m.Price).IsRequired().HasColumnType("decimal(8,2)").HasComment("Price of collection item").HasDefaultValue(0);
        entity.HasIndex(m => m.Name).HasDatabaseName("idx_CollectionItem_Name");
    }
}