using Autofac;
using CurrencyReading;
using GameteqTestApp.BL.AppServices;
using GameteqTestApp.DA.EFCore.Core;
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

	builder.RegisterModule<AppServicesRegistrationModule>();
	builder.RegisterModule<EfCoreRegistrationModule>();
	builder.RegisterModule<DaServicesRegistrationModule>();

	return builder.Build();
}

static void MigrateDatabase(IContainer container)
{
    using (var context = container.BeginLifetimeScope().Resolve<CurrencyAppContext>())
    {
        context.Database.Migrate();
    }
}