using Autofac;
using GameteqTestApp.DA.Services;
using GameteqTestApp.DA.Services.Interfaces;

namespace GameteqTestApp.BL.AppServices
{
	public class DaServicesRegistrationModule: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CurrencyService>().As<ICurrencyService>();
			builder.RegisterType<CurrencyRateService>().As<ICurrencyRateService>();
		}
	}
}
