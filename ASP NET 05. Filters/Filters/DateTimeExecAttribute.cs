using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_NET_05._Filters.Filters;

public class DateTimeExecAttribute : Attribute, IResultFilter
{
    public void OnResultExecuted(ResultExecutedContext context)
    {}

    public void OnResultExecuting(ResultExecutingContext context)
    {
        context
             .HttpContext
             .Response
             .Headers
             .Add("DateTime", DateTime.Now.ToString("ddd-dd-MMMM-yyyy"));
    }
}
