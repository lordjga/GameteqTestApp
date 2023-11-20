namespace GameteqTestApp.BL.ViewModels
{
	public class CurrencyRateViewModel
	{
		public int Id { get; set; }

		public int CurrencyId { get; set; }

		public decimal Rate { get; set; }

		public DateTime Date { get; set; }
	}
}