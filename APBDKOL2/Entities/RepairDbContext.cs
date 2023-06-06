using APBDKOL2.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace APBDKOL2.Entities;

public class RepairDbContext : DbContext
{
    public virtual DbSet<Make> Makes { get; set; }
    public virtual DbSet<Car> Cars { get; set; }
    public virtual DbSet<Mechanic> Mechanics { get; set; }
    public virtual DbSet<Specialization> Specializations { get; set; }
    
    public virtual DbSet<MechanicCar> MechanicCars { get; set; }

    public RepairDbContext()
    {
    }

    public RepairDbContext(DbContextOptions options) : base(options)
    {
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarEfConfiguration).Assembly);
    }
}