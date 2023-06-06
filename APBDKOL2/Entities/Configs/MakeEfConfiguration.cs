using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDKOL2.Entities.Configs;

public class MakeEfConfiguration : IEntityTypeConfiguration<Make>
{
    public void Configure(EntityTypeBuilder<Make> builder)
    {
        builder.HasKey(e => e.Id).HasName("Make_pk");
        builder.Property(e => e.Id).UseIdentityColumn();

        builder.Property(e => e.Name).HasMaxLength(255).IsRequired();

        builder.ToTable("Make");


        Make[] mk =
        {
            new Make()
            {
                Id = 1,
                Name = "Ford"
            },
            new Make()
            {
                Id = 2,
                Name = "Audi"
            }
        };
        builder.HasData(mk);
    }
}