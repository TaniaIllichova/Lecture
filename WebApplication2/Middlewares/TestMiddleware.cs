using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication2.Middlewares
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;

        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //throw new Exception("Exception from test middleware");

            await _next(httpContext);
        }
    }
}