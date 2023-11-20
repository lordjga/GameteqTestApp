using CurrencyRate.API.Controllers.Base;
using GameteqTestApp.BL.AppServices.Interfaces;
using GameteqTestApp.BL.ViewModels;
using GameteqTestApp.DA.Model;
using GameteqTestApp.DA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyRate.API.Controllers
{
	public class CurrencyController : BaseController
	{
		private readonly ICurrencyAppService _currencyAppService;

		public CurrencyController(ICurrencyAppService currencyAppService)
		{
			_currencyAppService = currencyAppService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<CurrencyViewModel>> Get()
		{
			return Ok(_currencyAppService.GetCurrensies());
		}

		[HttpGet("getRate")]
		public ActionResult<CurrencyRateViewModel> GetRate(int currencyId, DateTime date)
		{
			return Ok(_currencyAppService.GetRate(currencyId, date));
		}
	}
}