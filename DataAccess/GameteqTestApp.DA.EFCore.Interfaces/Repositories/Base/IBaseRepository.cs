using System.Linq.Expressions;

namespace GameteqTestApp.DA.EFCore.Interfaces.Repositories.Base
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		void Add(TEntity entity);

		void AddRange(IEnumerable<TEntity> entities);

		TEntity GetById<TKey>(TKey id);

		IQueryable<TEntity> GetAll(bool noTracking = false);

		IQueryable<TEntity> GetAllWithInclude(bool noTracking = false, params Expression<Func<TEntity, object>>[] includes);

		IQueryable<TEntity> GetAllWithFilter(Expression<Func<TEntity, bool>> filter, bool noTracking = false, params Expression<Func<TEntity, object>>[] includes);
	}
}
