using CurrencyRate.API.Filters.Base;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyRate.API.Controllers.Base;

[Route("api/[controller]")]
[TypeFilter(typeof(BaseFilterAttribute))]
[ApiController]
public class BaseController : Controller
{
}
