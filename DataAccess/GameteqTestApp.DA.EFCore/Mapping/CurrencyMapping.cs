using GameteqTestApp.DA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameteqTestApp.DA.EFCore.Mapping;
internal sealed class CurrencyMapping : IEntityTypeConfiguration<Currency>
{
	public void Configure(EntityTypeBuilder<Currency> builder)
	{
		builder.ToTable("Currencies");

		builder.HasKey(x => x.Id);
		builder.HasIndex(x => new { x.Name, x.Multiplier }).IsUnique();

		builder.Property(x => x.Id).HasColumnName("CurrencyId").IsRequired();
		builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar(40)").IsRequired();
		builder.Property(x => x.Multiplier).HasColumnName("Multiplier").IsRequired();

		builder.HasMany(x => x.CurrencyRates).WithOne(x => x.Currency).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);
	}
}
