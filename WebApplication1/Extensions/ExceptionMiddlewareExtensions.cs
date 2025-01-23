using Contracts.Interface;
using Entities.ErrorModel;
using Entities.Exceptions;


namespace CodeMazeProject1.Extensions
{
    using Microsoft.AspNetCore.Diagnostics;
    using System.Text.Json;

    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var statusCode = GetStatusCode(contextFeature.Error);
                        context.Response.StatusCode = statusCode;

                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        var errorDetails = new ErrorDetails
                        {
                            statusCode = statusCode,
                            message = contextFeature.Error.Message
                        };

                        var jsonResponse = JsonSerializer.Serialize(errorDetails);
                        await context.Response.WriteAsync(jsonResponse);
                    }
                });
            });
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
    }
}
