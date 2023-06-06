using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDKOL2.Entities.Configs;

public class SpecializationEfCongiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.HasKey(e => e.Id).HasName("Specialization_pk");
        builder.Property(e => e.Id).UseIdentityColumn();
        
        builder.Property(e => e.Name).IsRequired().HasMaxLength(255);

        builder.ToTable("Specialization");


        Specialization[] spec =
        {
            new Specialization()
            {
                Id = 1,
                Name = "EngineMaster"
            },
            new Specialization()
            {
                Id = 2,
                Name = "Engi"
            }
        };

        builder.HasData(spec);
    }
}