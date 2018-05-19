using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Modulos.IO.Services.Api.Middlewares
{
    public class SwaggerMiddleware
    {
        private readonly RequestDelegate _next;

        public SwaggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);
        }
    }

    public static class SwaggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SwaggerMiddleware>();
        }
    }
}
