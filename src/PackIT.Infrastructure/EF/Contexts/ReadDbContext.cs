using Microsoft.EntityFrameworkCore;
using PackIT.Infrastructure.EF.Config;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Contexts;

internal class ReadDbContext : DbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    public DbSet<PackingListReadModel> PackingLists { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var configuration = new ReadConfiguration();

        modelBuilder.HasDefaultSchema("packing");
        modelBuilder.ApplyConfiguration<PackingListReadModel>(configuration);
        modelBuilder.ApplyConfiguration<PackingItemReadModel>(configuration);

        base.OnModelCreating(modelBuilder);
    }
}