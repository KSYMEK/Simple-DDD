using Microsoft.EntityFrameworkCore;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;
using PackIT.Infrastructure.EF.Config;

namespace PackIT.Infrastructure.EF.Contexts;

internal class WriteDbContext : DbContext
{
    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    public DbSet<PackingList> PackingLists { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("packing");

        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<PackingItem>(configuration);
        modelBuilder.ApplyConfiguration<PackingList>(configuration);

        base.OnModelCreating(modelBuilder);
    }
}