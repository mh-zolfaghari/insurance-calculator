using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InsuranceCalculator.Infrastructure.Persistence.EF.Configs;

internal sealed class InsuranceRequestEntityConfig : IEntityTypeConfiguration<InsuranceRequest>
{
    public void Configure(EntityTypeBuilder<InsuranceRequest> builder)
    {
        builder.ToTable("InsuranceRequests");

        builder.HasKey(ir => ir.Id);

        builder.Property(ir => ir.Id)
               .HasConversion(new ValueConverter<BaseId, Guid>(id => id.Value, guid => new BaseId(guid)));

        builder.Property(ci => ci.UserId)
               .HasConversion(new ValueConverter<BaseId, Guid>(id => id.Value, guid => new BaseId(guid)))
               .IsRequired();

        builder.Property(u => u.Title)
               .HasColumnType("nvarchar")
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(u => u.CreatedAt)
               .IsRequired();

        builder.HasOne(ir => ir.User)
               .WithMany(x => x.InsuranceRequests)
               .HasForeignKey(ir => ir.UserId);

        builder.HasMany(ir => ir.Items)
               .WithOne(ci => ci.InsuranceRequest)
               .HasForeignKey(ci => ci.InsuranceRequestId);
    }
}
