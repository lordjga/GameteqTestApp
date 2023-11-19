using GameteqTestApp.BL.AppServices.Interfaces;
using GameteqTestApp.DA.Model;
using GameteqTestApp.DA.Services.Interfaces;
using System.Data;
using System.Text.RegularExpressions;

namespace GameteqTestApp.BL.AppServices
{
	public class CurrencyReader : ICurrencyReader
    {
		private const string GlobalDelimeter = "Date";
		private const char RowDelimeter = '\n';
		private const char ColumnDelimeter = '|';
		private const string DateTemplate = "dd.MM.yyyy";

		private readonly ICurrencyService _currencyService;
        private readonly ICurrencyRateService _currencyRateService;

		public CurrencyReader(ICurrencyService currencyService, ICurrencyRateService currencyRateService)
        {
            _currencyService = currencyService;
            _currencyRateService = currencyRateService;
        }

        public async Task<IEnumerable<Currency>> GetNewCurrenciesAsync(int year)
        {
            using var client = new HttpClient();
            string page = await client.GetStringAsync($"https://www.cnb.cz/en/financial_markets/foreign_exchange_market/exchange_rate_fixing/year.txt?year={year}");

            if (page == null || page.Length == 0)
                throw new HttpRequestException();

            var pageSections = Regex.Split(page, $"(?={GlobalDelimeter})").Where(x => x.Length > 0).ToArray();

			if (pageSections == null || pageSections.Length == 0)
				return null;

			var pageSectionsDevidedIntoLines = pageSections.Select(x => x.Split(RowDelimeter)).Where(x => x.Length > 0).ToArray();
            var currencies = new List<Currency>();

            for (int i = 0; i < pageSectionsDevidedIntoLines.Length; i++)
            {
                var headers = pageSectionsDevidedIntoLines[i][0].Split(ColumnDelimeter);
                var columns = pageSectionsDevidedIntoLines[i].Select(x => x.Split(ColumnDelimeter)).Where(x => x.Length > 1).ToArray();
                var dateColumn = columns.Select(x => x[0]).ToArray();

                for (int j = 1; j < columns[i].Length; j++)
                {
                    var column = columns.Select(x => x[j]).ToArray();
                    var currencyName = headers[j].Split(" ")[1];
                    var currencyMultiplier = headers[j].Split(" ")[0];

                    if (currencies.Any(x => x.Name == currencyName && x.Multiplier.ToString() == currencyMultiplier))
                    {
                        var currency = currencies.FirstOrDefault(x => x.Name == currencyName && x.Multiplier.ToString() == currencyMultiplier);
                        currency.CurrencyRates = (await CreateCurrencyRates(column, currency, dateColumn)).ToList();
                    }
                    else
                    {
                        var currency = new Currency
                        {
                            Name = currencyName,
                            Multiplier = int.Parse(currencyMultiplier)
                        };

                        currency.CurrencyRates = (await CreateCurrencyRates(column, currency, dateColumn)).ToList();
                        currencies.Add(currency);
                    }
                }
            }

            return currencies;
        }

        public void SaveCurrencies(IEnumerable<Currency> currencies)
        {
            if (currencies == null || !currencies.Any())
                throw new ArgumentNullException(nameof(currencies));

            int year = currencies.First().CurrencyRates.First().Date.Year;
            var allExistedCurrencies = _currencyService.GetAll(true).ToList();
            var existedCurrencyRatesByYear = _currencyRateService.GetAll( x => x.Date.Year == year, true).ToList();

			foreach (var currency in currencies)
            {
                if (allExistedCurrencies.Any(x => x.Name == currency.Name && x.Multiplier == currency.Multiplier))
                {
                    var existedCurrency = allExistedCurrencies.SingleOrDefault(x => x.Name == currency.Name && x.Multiplier == currency.Multiplier);
                    currency.Id = existedCurrency.Id;
                    currency.CurrencyRates.ForEach(x => x.CurrencyId = currency.Id);
                }
            }

            var newCurrencies = currencies.Where(x => x.Id == 0).ToList();
            var newCurrencyRates = currencies.Where(y => y.Id != 0).SelectMany(x => x.CurrencyRates).ToList();

            if (existedCurrencyRatesByYear.Any() && newCurrencyRates.Any())
            {
                newCurrencyRates = newCurrencyRates
                    .Where(y => !existedCurrencyRatesByYear.Any(u => u.CurrencyId == y.CurrencyId && u.Date == y.Date)).ToList();
            }

            if (newCurrencies.Any())
                _currencyService.AddRange(newCurrencies);

            if (newCurrencyRates.Any())
                _currencyRateService.AddRange(newCurrencyRates);
        }

        private async Task<IEnumerable<CurrencyRate>> CreateCurrencyRates(string[] column, Currency currency, string[] dateColumn)
        {
            if (column == null)
                throw new ArgumentNullException(nameof(column));

            if (dateColumn == null)
                throw new ArgumentNullException(nameof(dateColumn));

            var currencyRates = new List<CurrencyRate>();

            await Task.Run(() =>
            {
                for (int u = 1; u < column.Count(); u++)
                {
                    currencyRates.Add(new CurrencyRate()
                    {
                        Currency = currency,
                        CurrencyId = currency.Id,
                        Date = DateTime.ParseExact(dateColumn[u], DateTemplate, null),
                        Rate = decimal.Parse(column[u].ToString())
                    });
                }
            });

            return currencyRates;
        }
    }
}