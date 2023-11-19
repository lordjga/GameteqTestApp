using GameteqTestApp.DA.EFCore.Interfaces.Core;
using GameteqTestApp.DA.EFCore.Interfaces.Repositories.Base;
using GameteqTestApp.DA.Services.Interfaces.Base;
using System.Linq.Expressions;

namespace GameteqTestApp.DA.Services.Base
{
	public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
	{
		protected readonly IUnitOfWork UnitOfWork;

		protected IBaseRepository<TEntity> WorkRepository => UnitOfWork.GetBaseRepository<TEntity>();

		protected BaseService(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}

		public virtual void Add(TEntity item)
		{
			WorkRepository.Add(item);
			UnitOfWork.SaveChanges();
		}

		public virtual void AddRange(IEnumerable<TEntity> items)
		{
			WorkRepository.AddRange(items);
			UnitOfWork.SaveChanges();
		}

		public virtual TEntity GetById<TKey>(TKey id)
		{
			return WorkRepository.GetById(id);
		}

		public virtual IQueryable<TEntity> GetAll(bool noTracking = false)
		{
			return WorkRepository.GetAll(noTracking);
		}

		public virtual IQueryable<TEntity> GetAllWithInclude(bool noTracking = false, params Expression<Func<TEntity, object>>[] includes)
		{
			return WorkRepository.GetAllWithInclude(noTracking, includes);
		}

		public virtual IEnumerable<TEntity> GetAll(Expression < Func<TEntity, bool>> filter, bool noTracking = false, params Expression<Func<TEntity, object>>[] includes)
		{
			return WorkRepository.GetAllWithFilter(filter, noTracking, includes);
		}
	}
}
