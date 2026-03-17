using ImportWizard.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImportWizard.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ImportRun> ImportRuns => Set<ImportRun>();
    public DbSet<ImportRowError> ImportRowErrors => Set<ImportRowError>();
    public DbSet<ImportedRecord> ImportedRecords => Set<ImportedRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ImportRun>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FileName).IsRequired().HasMaxLength(512);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
        });

        modelBuilder.Entity<ImportRowError>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Column).HasMaxLength(256);
            entity.Property(e => e.Message).IsRequired();
            entity.HasOne(e => e.ImportRun)
                  .WithMany(r => r.RowErrors)
                  .HasForeignKey(e => e.ImportRunId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ImportedRecord>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DataJson).IsRequired();
            entity.HasOne(e => e.ImportRun)
                  .WithMany(r => r.ImportedRecords)
                  .HasForeignKey(e => e.ImportRunId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
