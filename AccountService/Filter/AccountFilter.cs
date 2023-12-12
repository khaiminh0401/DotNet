using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AccountService.Filter;

public class AccountFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public  void OnActionExecuting(ActionExecutingContext context)
    {
        string? path = context.HttpContext.Request.Path.Value;
        if (path.Contains("/account") && !path.Contains("/login"))
        {
            string? session = context.HttpContext.Session.GetString("account");
            if (session == null || session == "")
            {
                context.HttpContext.Response.Redirect("/api/account/error");
            }
        }
    }
}