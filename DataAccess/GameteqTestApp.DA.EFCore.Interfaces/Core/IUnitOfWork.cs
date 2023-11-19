using GameteqTestApp.DA.EFCore.Interfaces.Repositories.Base;

namespace GameteqTestApp.DA.EFCore.Interfaces.Core
{
	public interface IUnitOfWork: IDisposable
	{
		IBaseRepository<TEntity> GetBaseRepository<TEntity>() where TEntity : class;

		int SaveChanges();
	}
}
