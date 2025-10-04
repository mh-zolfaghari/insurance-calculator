using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InsuranceCalculator.Infrastructure.Persistence.EF.Configs;

internal sealed class CoverageDefinitionEntityConfig : IEntityTypeConfiguration<CoverageDefinition>
{
    public void Configure(EntityTypeBuilder<CoverageDefinition> builder)
    {
        builder.ToTable("CoverageDefinition");

        builder.HasKey(cd => cd.Id);

        builder.Property(cd => cd.Id)
               .HasConversion(new ValueConverter<BaseId, Guid>(id => id.Value, guid => new BaseId(guid)));

        builder.Property(u => u.Name)
               .HasColumnType("nvarchar")
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(u => u.PremiumRate)
               .HasPrecision(18, 5)
               .IsRequired();

        builder.Property(typeof(Price), nameof(CoverageDefinition.Minimum))
               .HasConversion(new ValueConverter<Price, decimal>(min => min.Amount, min => new Price(min)))
               .HasPrecision(18, 2)
               .HasColumnName(nameof(CoverageDefinition.Minimum))
               .IsRequired();

        builder.Property(typeof(Price), nameof(CoverageDefinition.Maximum))
               .HasConversion(new ValueConverter<Price, decimal>(min => min.Amount, min => new Price(min)))
               .HasPrecision(18, 2)
               .HasColumnName(nameof(CoverageDefinition.Maximum))
               .IsRequired();

        builder.HasIndex(cd => cd.Name)
               .IsUnique();

        builder.HasMany(cd => cd.CoverageItems)
               .WithOne(ci => ci.CoverageDefinition)
               .HasForeignKey(ci => ci.CoverageDefinitionId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
