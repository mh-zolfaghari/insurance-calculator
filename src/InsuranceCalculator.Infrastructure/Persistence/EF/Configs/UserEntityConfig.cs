using InsuranceCalculator.Domain.Entities.UserManagement;
using InsuranceCalculator.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InsuranceCalculator.Infrastructure.Persistence.EF.Configs;

internal sealed class UserEntityConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
               .HasConversion(new ValueConverter<BaseId, Guid>(id => id.Value, guid => new BaseId(guid)));

        builder.Property(u => u.Token)
               .IsRequired();

        builder.Property(u => u.FirstName)
               .HasColumnType("nvarchar")
               .HasMaxLength(100);

        builder.Property(u => u.LastName)
               .HasColumnType("nvarchar")
               .HasMaxLength(100);

        builder.HasMany(u => u.InsuranceRequests)
               .WithOne(ir => ir.User)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
