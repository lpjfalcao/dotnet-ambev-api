using Ambev.DeveloperEvaluation.WebApi.Common;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Ambev.DeveloperEvaluation.WebApi.Middleware
{
    public static class GlobalHandlerErrorMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            DetaileError = contextFeature?.Error?.InnerException?.Message ?? ""
                        }.ToString());
                    }
                });
            });
        }
    }
}
