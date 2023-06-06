using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDKOL2.Entities.Configs;

public class MechanicEfConfiguration : IEntityTypeConfiguration<Mechanic>
{
    public void Configure(EntityTypeBuilder<Mechanic> builder)
    {
        builder.HasKey(e => e.Id).HasName("Mechanic_pk");
        builder.Property(e => e.Id).UseIdentityColumn();
        
        builder.Property(e => e.FirstName).HasMaxLength(255).IsRequired();
        builder.Property(e => e.LastName).HasMaxLength(255).IsRequired();
        builder.Property(e => e.Nickname).HasMaxLength(255);

        builder.HasOne(e => e.Specialization)
            .WithMany(e => e.Mechanics)
            .HasForeignKey(e => e.Specialization_Id)
            .HasConstraintName("Mechanic_Specialization")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Mechanic");


        Mechanic[] mec =
        {
            new Mechanic()
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Illarionov",
                Nickname = "Remmy",
                Specialization_Id = 1
            },
            new Mechanic()
            {
                Id = 2,
                FirstName = "Joe",
                LastName = "Barbaro",
                Nickname = "Black hand",
                Specialization_Id = 2
            }
        };
        
        builder.HasData(mec);
    }
}