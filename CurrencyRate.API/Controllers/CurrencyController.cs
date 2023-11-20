using CurrencyRate.API.Controllers.Base;
using GameteqTestApp.DA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyRate.API.Controllers
{
	[Produces("application/json")]
	public class CurrencyController : BaseController
	{
		private readonly ILogger<CurrencyController> _logger;
		private readonly ICurrencyService _currencyService;

		public CurrencyController(ILogger<CurrencyController> logger, ICurrencyService currencyService)
		{
			_logger = logger;
			_currencyService = currencyService;
		}

		[HttpGet("getAllCurrencies")]
		public IActionResult Get()
		{
			return Ok(_currencyService.GetAll(true));
		}
	}
}