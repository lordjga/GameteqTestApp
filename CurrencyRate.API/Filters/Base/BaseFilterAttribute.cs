using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CurrencyRate.API.Filters.Base;

[AttributeUsage(AttributeTargets.Class)]
public class BaseFilterAttribute : ExceptionFilterAttribute
{
	private readonly ILogger<BaseFilterAttribute> _logger;

	public BaseFilterAttribute(ILogger<BaseFilterAttribute> logger)
	{
		_logger = logger;
	}

	public void OnException(ExceptionContext context)
    {
        var actionName = context.ActionDescriptor.DisplayName;
        var exceptionStack = context.Exception.StackTrace;
        var exceptionMessage = context.Exception.Message;
        var warning = $"Method {actionName} threw an exception: \n\n{exceptionMessage}";

        context.Result = new ContentResult
        {
            Content = warning,
            StatusCode = (int)HttpStatusCode.BadRequest
        };

		_logger.LogWarning(warning + $"\n{exceptionStack}");

        context.ExceptionHandled = true;
    }
}
