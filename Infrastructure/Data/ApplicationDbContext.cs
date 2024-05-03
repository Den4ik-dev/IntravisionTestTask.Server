using System.Reflection;
using Domain.DrinkLine;
using Domain.MachineWithDrinks;
using Domain.MachineWithDrinks.ValueObject;
using Domain.Nominal;
using Domain.Nominal.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<MachineWithDrinks> MachinesWithDrinks => Set<MachineWithDrinks>();
    public DbSet<DrinkLine> DrinkLines => Set<DrinkLine>();
    public DbSet<Nominal> Nominals => Set<Nominal>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<MachineWithDrinks>()
            .HasData(MachineWithDrinks.CreateWithId(MachineWithDrinksId.Create(1)));

        modelBuilder
            .Entity<Nominal>()
            .HasData(
                Nominal.CreateWithId(NominalId.Create(1), 1),
                Nominal.CreateWithId(NominalId.Create(2), 2),
                Nominal.CreateWithId(NominalId.Create(3), 5),
                Nominal.CreateWithId(NominalId.Create(4), 10)
            );

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
