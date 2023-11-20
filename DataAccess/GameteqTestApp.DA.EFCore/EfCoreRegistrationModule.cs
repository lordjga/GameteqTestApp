using Autofac;
using GameteqTestApp.DA.EFCore.Core;
using GameteqTestApp.DA.EFCore.Interfaces.Core;

namespace GameteqTestApp.BL.AppServices
{
	public class EfCoreRegistrationModule: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
		}
	}
}
