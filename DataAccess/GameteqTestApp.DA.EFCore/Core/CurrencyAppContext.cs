using GameteqTestApp.DA.EFCore.Mapping.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace GameteqTestApp.DA.EFCore.Core
{
	public class CurrencyAppContext : DbContext
	{
		public CurrencyAppContext() : base() { }

		public CurrencyAppContext(DbContextOptions<CurrencyAppContext> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var appAssembly = Assembly.Load(GetType().Assembly.FullName);
			var configuration = new ConfigurationBuilder()
				.AddUserSecrets(appAssembly, true, false)
				.Build();

			var dbConnectionString = configuration.GetConnectionString("DefaultConnection");
			optionsBuilder.UseSqlServer(dbConnectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			EntityMappingConfig.RegisterMappings(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}
	}
}
