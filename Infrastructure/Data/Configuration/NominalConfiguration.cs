using Domain.Nominal;
using Domain.Nominal.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class NominalConfiguration : IEntityTypeConfiguration<Nominal>
{
    public void Configure(EntityTypeBuilder<Nominal> builder)
    {
        builder.ToTable("nominals");

        builder.HasKey(n => n.Id);
        builder
            .Property(n => n.Id)
            .HasConversion(nominalId => nominalId.Value, value => NominalId.Create(value))
            .HasColumnName("nominal_id");

        builder.Property(n => n.Value).HasColumnName("value");
        builder.HasIndex(n => n.Value).IsUnique();

        builder.Property(n => n.IsBlocked).HasColumnName("is_blocked");
    }
}
