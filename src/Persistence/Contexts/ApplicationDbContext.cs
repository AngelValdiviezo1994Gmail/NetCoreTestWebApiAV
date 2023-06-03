


using WebApiTest.Domain.Entities.Acontecimientos;
using WebApiTest.Domain.Entities.Clientes;
using WebApiTest.Domain.Entities.Eventos;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Domain.Entities;

namespace WebApiTest.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    //Declarar siempre todos los modelosa usar
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    }
    
    public DbSet<tblEventoNextTi> eventosModels => Set<tblEventoNextTi>();
    public DbSet<AcontecimientosModels> acontecimientosModels => Set<AcontecimientosModels>();
    public DbSet<ClientesModels> clientesModels => Set<ClientesModels>();
    public DbSet<Adjuntos> adjuntosModels => Set<Adjuntos>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
    //    {
    //        switch (entry.State)
    //        {
    //            case EntityState.Added:
    //                entry.Entity.Created = _dateTimeService.NowUtc;
    //                entry.Entity.Uid = new Guid();
    //                break;
    //            case EntityState.Modified:
    //                entry.Entity.LastModified = _dateTimeService.NowUtc;
    //                break;
    //        }
    //    }
    //    return await base.SaveChangesAsync(cancellationToken);
    //}
}