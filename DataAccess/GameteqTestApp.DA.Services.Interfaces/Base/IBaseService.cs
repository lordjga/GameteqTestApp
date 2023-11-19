using System.Linq.Expressions;

namespace GameteqTestApp.DA.Services.Interfaces.Base
{
    public interface IBaseService<TEntity> where TEntity : class
	{
		void Add(TEntity item);

		void AddRange(IEnumerable<TEntity> item);

		TEntity GetById<TKey>(TKey id);

        IQueryable<TEntity> GetAll(bool noTracking = false);

        IQueryable<TEntity> GetAllWithInclude(bool noTracking = false, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter, bool noTracking = false, params Expression<Func<TEntity, object>>[] includes);
    }
}
