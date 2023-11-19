using GameteqTestApp.DA.Model;

namespace GameteqTestApp.BL.AppServices.Interfaces
{
	public interface ICurrencyReader
	{
		Task<IEnumerable<Currency>> GetNewCurrenciesAsync(int year);

		void SaveCurrencies(IEnumerable<Currency> currencies);
	}
}
