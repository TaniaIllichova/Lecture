using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication2.Filters
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("New", "HiFromActionFilter");

            // Do something after the action executes.
        }
    }
}