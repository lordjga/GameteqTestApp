using GameteqTestApp.DA.EFCore.Interfaces.Core;
using GameteqTestApp.DA.EFCore.Interfaces.Repositories.Base;
using GameteqTestApp.DA.EFCore.Repositories.Base;

namespace GameteqTestApp.DA.EFCore.Core
{
	public class UnitOfWork : IUnitOfWork
    {
        private readonly CurrencyAppContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(CurrencyAppContext context)
        {
			_context = context;
			_repositories = new Dictionary<Type, object>();
		}

        public IBaseRepository<TEntity> GetBaseRepository<TEntity>() where TEntity : class
        {
			if (_repositories.ContainsKey(typeof(TEntity)))
			{
				return (IBaseRepository<TEntity>)_repositories[typeof(TEntity)];
			}

			var repository = new BaseRepository<TEntity>(_context);
			_repositories.Add(typeof(TEntity), repository);
			return repository;
		}

		public int SaveChanges()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
        {
			_context.Dispose();
		}
    }
}
