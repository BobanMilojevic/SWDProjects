using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Swd.PlayCollector.Model;

public class TypeOfDocumentConfig : IEntityTypeConfiguration<TypeOfDocument>
{
    public void Configure(EntityTypeBuilder<TypeOfDocument> builder)
    {
        builder.HasKey(m => m.Id)
            .IsClustered(true);
        
        builder.Property(m => m.TypeName)
            .IsRequired()
            .HasColumnType("nvarchar(50)");
        
        builder.HasIndex(m => m.TypeName)
            .HasDatabaseName("idx_TypeOfDocument_TypeName");
    }
}