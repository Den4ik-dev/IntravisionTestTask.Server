using Domain.DrinkLine;
using Domain.DrinkLine.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class DrinkLineConfiguration : IEntityTypeConfiguration<Domain.DrinkLine.DrinkLine>
{
    public void Configure(EntityTypeBuilder<DrinkLine> builder)
    {
        builder.ToTable("drink_lines");

        builder.HasKey(dl => dl.Id);
        builder
            .Property(dl => dl.Id)
            .HasConversion(drinkId => drinkId.Value, value => DrinkLineId.Create(value))
            .ValueGeneratedNever()
            .HasColumnName("drink_line_id");

        builder
            .Property(dl => dl.DrinksQuantityInMachine)
            .HasColumnName("drinks_quantity_in_machine");

        builder.OwnsOne(
            dl => dl.Drink,
            builder =>
            {
                builder.Property(d => d.Name).HasColumnName("name");
                builder.HasIndex(d => d.Name).IsUnique();

                builder
                    .Property(d => d.Image)
                    .HasConversion(image => image!.Path, value => Image.Create(value))
                    .HasColumnName("image_path");

                builder
                    .Property(d => d.Price)
                    .HasConversion(price => price.Value, value => Price.Create(value))
                    .HasColumnName("price");
            }
        );
    }
}
