using GameteqTestApp.DA.EFCore.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace GameteqTestApp.DA.EFCore.Migrations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CurrencyAppContext>
    {
        public CurrencyAppContext CreateDbContext(string[] args)
        {
            var appAssembly = Assembly.Load(GetType().Assembly.FullName);

            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    //.AddUserSecrets(appAssembly, true, false)
                    .Build();

            var builder = new DbContextOptionsBuilder<CurrencyAppContext>();

            builder.UseSqlServer(@"Server=LEGION;Database=helloappdb;Trusted_Connection=True;TrustServerCertificate=True", x =>
            {
                x.MigrationsAssembly(GetType().Assembly.FullName);
            });

            return new CurrencyAppContext(builder.Options);
        }
    }
}