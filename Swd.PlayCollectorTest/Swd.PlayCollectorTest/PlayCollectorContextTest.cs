using Microsoft.EntityFrameworkCore;

namespace Swd.PlayCollectorTest;

public class PlayCollectorContextTest : DbContext
{
    public DbSet<Media> Media { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        string connectionString = "data source=.;initial catalog=Swd.PlayCollectorTest;integrated security=True;TrustServerCertificate=True;Trusted_Connection=True;";
        
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new MediaConfig());
        modelBuilder.ApplyConfiguration(new TypeOfDocumentConfig());
    }
}