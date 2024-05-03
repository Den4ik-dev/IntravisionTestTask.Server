using Domain.MachineWithDrinks;
using Domain.MachineWithDrinks.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class MachineWithDrinksConfiguration : IEntityTypeConfiguration<MachineWithDrinks>
{
    public void Configure(EntityTypeBuilder<MachineWithDrinks> builder)
    {
        builder.ToTable("machines_with_drinks");

        builder.HasKey(m => m.Id);
        builder
            .Property(m => m.Id)
            .HasConversion(
                machineWithDrinksId => machineWithDrinksId.Value,
                value => MachineWithDrinksId.Create(value)
            )
            .HasColumnName("machine_with_drink_id");

        builder.Property(m => m.CoinsQuantity).HasColumnName("coins_quantity");
    }
}
