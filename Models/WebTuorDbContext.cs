using Microsoft.EntityFrameworkCore;

namespace WebTuor.Models;

public class WebTuorDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> User => Set<User>();
    public DbSet<Passeio> Passeio => Set<Passeio>();
    public DbSet<Visita> Visita => Set<Visita>();
    public DbSet<PontoTuristico> PontoTuristico => Set<PontoTuristico>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Visita>()
            .HasOne(v => v.Passeio)
            .WithMany(p => p.Visitas)
            .HasForeignKey(v => v.PasseioId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Visita>()
            .HasOne(v => v.PontoTuristico)
            .WithMany(pt => pt.Visitas)
            .HasForeignKey(v => v.PontoTuristicoId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Passeio>()
            .HasOne(p => p.Owner)
            .WithMany(o => o.Passeios)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}