using GameteqTestApp.DA.EFCore.Interfaces.Core;
using GameteqTestApp.DA.Model;
using GameteqTestApp.DA.Services.Base;
using GameteqTestApp.DA.Services.Interfaces;

namespace GameteqTestApp.DA.Services
{
	public class CurrencyService : BaseService<Currency>, ICurrencyService
	{
		public CurrencyService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}
