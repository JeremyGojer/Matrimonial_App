using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Happy_Marriage.Exceptions
{
    public class SessionExpiryResponseFilter : IActionFilter
    {

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is SessionExpiredException) {
                context.Result = new RedirectToActionResult("Index","Home",new Object());
                
            }
            
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context) {}
    }
}
