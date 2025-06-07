using FelipeDiasAzevedo.TCS.Infra.Models.Clipboard;
using Microsoft.EntityFrameworkCore;

namespace FelipeDiasAzevedo.TCS.Infra.Options;

public class DatabaseContext : DbContext
{
    public DbSet<ClipboardModel> Clipboards { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        _ = Database.EnsureCreatedAsync().Result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClipboardModel>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
    }
}
