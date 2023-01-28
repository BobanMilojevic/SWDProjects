using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Swd.PlayCollector.Model;

public class MediaConfig : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.HasKey(m => m.Id).IsClustered(true);
        builder.Property(m => m.Name).
            IsRequired().
            HasColumnType("nvarchar(50)").
            HasComment("Name of media item");
        builder.Property(m => m.Uri).
            HasColumnType("nvarchar(255)").
            IsUnicode(false);
        builder.HasIndex(m => m.Name).HasDatabaseName("idx_Media_Name");
    }
}