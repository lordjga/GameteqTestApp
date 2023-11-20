using GameteqTestApp.DA.Model;
using Microsoft.EntityFrameworkCore;

namespace GameteqTestApp.DA.EFCore.Mapping.Config;
internal class EntityMappingConfig
{
	internal static void RegisterMappings(ModelBuilder modelBuilder)
	{
		new CurrencyMapping().Configure(modelBuilder.Entity<Currency>());
		new CurrencyRateMapping().Configure(modelBuilder.Entity<CurrencyRate>());
	}
}
