using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_NET_05._Filters.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is KeyNotFoundException ||
            context.Exception is NullReferenceException)
        {
            context.Result = new RedirectResult("/home/error");
        }
        else if(context.Exception is DivideByZeroException)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
