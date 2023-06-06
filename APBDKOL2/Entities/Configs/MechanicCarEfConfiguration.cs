using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDKOL2.Entities.Configs;

public class MechanicCarEfConfiguration : IEntityTypeConfiguration<MechanicCar>
{
    public void Configure(EntityTypeBuilder<MechanicCar> builder)
    {
        builder.HasKey(e => new { e.Mechanic_Id, e.Car_Id }).HasName("MechanicCar_pk");

        builder.HasOne(e => e.Mechanic)
            .WithMany(e => e.MechanicCars)
            .HasForeignKey(e => e.Mechanic_Id)
            .HasConstraintName("MechanicCar_Mechanic")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(e => e.Car)
            .WithMany(e => e.MechanicCars)
            .HasForeignKey(e => e.Car_Id)
            .HasConstraintName("MechanicCar_Car")
            .OnDelete(DeleteBehavior.Restrict);


        builder.ToTable("MechanicCar");


        MechanicCar[] mc =
        {
            new MechanicCar()
            {
                Mechanic_Id = 1,
                Car_Id = 1
            },
            new MechanicCar()
            {
                Mechanic_Id = 2,
                Car_Id = 2
            }
        };
        builder.HasData(mc);
    }
}