using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InsuranceCalculator.Infrastructure.Persistence.EF.Configs;

internal sealed class CoverageItemEntityConfig : IEntityTypeConfiguration<CoverageItem>
{
    public void Configure(EntityTypeBuilder<CoverageItem> builder)
    {
        builder.ToTable("CoverageItems");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
               .HasConversion(new ValueConverter<BaseId, Guid>(id => id.Value, guid => new BaseId(guid)));

        builder.Property(ci => ci.CoverageDefinitionId)
               .HasConversion(new ValueConverter<BaseId, Guid>(id => id.Value, guid => new BaseId(guid)))
               .IsRequired();

        builder.Property(ci => ci.InsuranceRequestId)
               .HasConversion(new ValueConverter<BaseId, Guid>(id => id.Value, guid => new BaseId(guid)))
               .IsRequired();

        builder.Property(typeof(Price), nameof(CoverageItem.Capital))
               .HasConversion(new ValueConverter<Price, decimal>(min => min.Amount, min => new Price(min)))
               .HasPrecision(18, 2)
               .HasColumnName(nameof(CoverageItem.Capital))
               .IsRequired();

        builder.Property(typeof(Price), nameof(CoverageItem.Premium))
               .HasConversion(new ValueConverter<Price, decimal>(min => min.Amount, min => new Price(min)))
               .HasPrecision(18, 2)
               .HasColumnName(nameof(CoverageItem.Premium))
               .IsRequired();

        builder.HasIndex(ci => new { ci.InsuranceRequestId, ci.CoverageDefinitionId })
               .IsUnique();

        builder.HasOne(ci => ci.InsuranceRequest)
                .WithMany(ir => ir.Items)
                .HasForeignKey(ci => ci.InsuranceRequestId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ci => ci.CoverageDefinition)
                .WithMany(cd => cd.CoverageItems)
                .HasForeignKey(ci => ci.CoverageDefinitionId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
