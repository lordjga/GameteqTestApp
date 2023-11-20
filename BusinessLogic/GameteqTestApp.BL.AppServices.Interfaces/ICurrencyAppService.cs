using GameteqTestApp.BL.ViewModels;
using GameteqTestApp.DA.Model;

namespace GameteqTestApp.BL.AppServices.Interfaces
{
	public interface ICurrencyAppService
	{
		Task<IEnumerable<Currency>> ParseNewCurrenciesAsync(int year);

		void SaveCurrencies(IEnumerable<Currency> currencies);

		IEnumerable<CurrencyViewModel> GetCurrensies();

		CurrencyRateViewModel GetRate(int currencyId, DateTime date);
	}
}
