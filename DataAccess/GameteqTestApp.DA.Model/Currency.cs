namespace GameteqTestApp.DA.Model
{
	public class Currency
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Multiplier { get; set; }

		public virtual List<CurrencyRate> CurrencyRates { get; set; }
	}
}
