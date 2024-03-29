﻿using GameteqTestApp.BL.AppServices.Interfaces;

namespace CurrencyReading
{
	class Application
	{
		protected readonly ICurrencyAppService _currencyReader;

		public Application(ICurrencyAppService currencyReader)
		{
			_currencyReader = currencyReader;
		}

		public async void Run()
		{
			Console.WriteLine("Input year between 1991 and 2023: ");
			var inputString = Console.ReadLine();

			if (!int.TryParse(inputString, out int year) || year > 2023 || year < 1991)
			{
				Console.WriteLine("Incorrect input.");
				return;
			}

			var list = await _currencyReader.ParseNewCurrenciesAsync(year);

			if(list != null) 
				_currencyReader.SaveCurrencies(list);
		}
	}
}
