using GameteqTestApp.DA.EFCore.Interfaces.Core;
using GameteqTestApp.DA.Model;
using GameteqTestApp.DA.Services.Base;
using GameteqTestApp.DA.Services.Interfaces;

namespace GameteqTestApp.DA.Services
{
	public class CurrencyRateService : BaseService<CurrencyRate>, ICurrencyRateService
	{
		public CurrencyRateService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public override void AddRange(IEnumerable<CurrencyRate> items)
		{
			PrepareBeforeDatabaseSave(items);
			base.AddRange(items);
		}

		private void PrepareBeforeDatabaseSave(IEnumerable<CurrencyRate> items)
		{
			foreach (var item in items)
			{
				if (item.Currency != null)
					item.Currency = null;
			}
		}
	}
}
