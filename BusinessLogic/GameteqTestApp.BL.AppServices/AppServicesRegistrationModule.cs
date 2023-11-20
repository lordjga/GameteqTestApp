using Autofac;
using GameteqTestApp.BL.AppServices.Interfaces;

namespace GameteqTestApp.BL.AppServices
{
	public class AppServicesRegistrationModule: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CurrencyAppService>().As<ICurrencyAppService>();
		}
	}
}
