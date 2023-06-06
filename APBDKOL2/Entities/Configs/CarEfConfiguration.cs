using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDKOL2.Entities.Configs;

public class CarEfConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(e => e.Id).HasName("Car_pk");
        builder.Property(e => e.Id).UseIdentityColumn();

        builder.Property(e => e.RegistrationPlate).HasMaxLength(255).IsRequired();
        builder.Property(e => e.ProductionYear).IsRequired();

        
        builder.HasOne(e => e.Make)
            .WithMany(e => e.Cars)
            .HasForeignKey(e => e.Make_Id)
            .HasConstraintName("Car_Make")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Car");


        Car[] cars =
        {
            new Car()
            {
                Id = 1,
                RegistrationPlate = "A777AA77",
                ProductionYear = DateTime.Today,
                Make_Id = 1
            },
            new Car()
            {
                Id = 2,
                RegistrationPlate = "O777OO77",
                ProductionYear = DateTime.Today,
                Make_Id = 2
            },
        };

        builder.HasData(cars);
    }
}