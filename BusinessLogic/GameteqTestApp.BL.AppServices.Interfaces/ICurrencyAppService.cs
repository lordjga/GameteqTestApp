using GameteqTestApp.DA.Model;

namespace GameteqTestApp.BL.AppServices.Interfaces
{
	public interface ICurrencyAppService
	{
		Task<IEnumerable<Currency>> GetNewCurrenciesAsync(int year);

		void SaveCurrencies(IEnumerable<Currency> currencies);
	}
}
