using Autofac;
using CurrencyReading;
using GameteqTestApp.BL.AppServices;
using GameteqTestApp.BL.AppServices.Interfaces;
using GameteqTestApp.DA.EFCore.Core;
using GameteqTestApp.DA.EFCore.Interfaces.Core;
using GameteqTestApp.DA.Services;
using GameteqTestApp.DA.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var container = BuildContainer();
MigrateDatabase(container);
container.Resolve<Application>().Run();

Console.ReadLine();


static IContainer BuildContainer()
{
    var builder = new ContainerBuilder();
    builder.RegisterType<Application>();
    builder.RegisterType<CurrencyAppContext>().InstancePerLifetimeScope();
	builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
	builder.RegisterType<CurrencyReader>().As<ICurrencyReader>();
	builder.RegisterType<CurrencyService>().As<ICurrencyService>();
	builder.RegisterType<CurrencyRateService>().As<ICurrencyRateService>();
	return builder.Build();
}

static void MigrateDatabase(IContainer container)
{
    using (var context = container.BeginLifetimeScope().Resolve<CurrencyAppContext>())
    {
        context.Database.Migrate();
    }
}