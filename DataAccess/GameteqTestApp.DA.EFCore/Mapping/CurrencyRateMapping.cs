using GameteqTestApp.DA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameteqTestApp.DA.EFCore.Mapping;
internal sealed class CurrencyRateMapping : IEntityTypeConfiguration<CurrencyRate>
{
    public void Configure(EntityTypeBuilder<CurrencyRate> builder)
    {
        builder.ToTable("CurrencyRates");

		builder.HasKey(x => x.Id);
		builder.HasIndex(x => new { x.CurrencyId, x.Date }).IsUnique();

		builder.Property(x => x.CurrencyId).HasColumnName("CurrencyId").IsRequired();
        builder.Property(x => x.Rate).HasColumnName("Rate").HasColumnType("decimal(7,3)").IsRequired();
		builder.Property(x => x.Date).HasColumnName("Date").HasColumnType("Date").IsRequired();

		builder.HasOne(x => x.Currency).WithMany(x => x.CurrencyRates).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);

	}
}
