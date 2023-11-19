using GameteqTestApp.DA.EFCore.Core;
using GameteqTestApp.DA.EFCore.Helpers;
using GameteqTestApp.DA.EFCore.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameteqTestApp.DA.EFCore.Repositories.Base
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
		private readonly CurrencyAppContext _context;
		private readonly DbSet<TEntity> _dbSet;

		public BaseRepository(CurrencyAppContext context)
		{
			_context = context;
			_dbSet = context.Set<TEntity>();
		}

		public void Add(TEntity entity)
		{
			_dbSet.Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			_dbSet.AddRange(entities);
		}

		public TEntity GetById<TKey>(TKey id)
		{
			return _dbSet.Find(id);
		}

		public IQueryable<TEntity> GetAll(bool noTracking = false)
		{
			return noTracking ? _dbSet.AsNoTracking().AsQueryable() : _dbSet.AsQueryable();
		}

		public IQueryable<TEntity> GetAllWithInclude(bool noTracking = false, params Expression<Func<TEntity, object>>[] includes)
		{
			return GetAll(noTracking).IncludeMultiple(includes);
		}

		public IQueryable<TEntity> GetAllWithFilter(Expression<Func<TEntity, bool>> filter, bool noTracking = false, params Expression<Func<TEntity, object>>[] includes)
		{
			return GetAllWithInclude(noTracking, includes).Where(filter);
		}



		public bool Delete(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public bool Delete<TKey>(TKey id)
		{
			throw new NotImplementedException();
		}

		public void DeleteRange(IEnumerable<TEntity> entities)
		{
			throw new NotImplementedException();
		}

		public bool Exists<TKey>(TKey id)
		{
			throw new NotImplementedException();
		}

		public void Update(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public void UpdateRange(IEnumerable<TEntity> entities)
		{
			throw new NotImplementedException();
		}
	}
}
