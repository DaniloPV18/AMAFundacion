using FundacionAMA.Application.DTO;

using System.Net;
using System.Text.Json;

namespace FundacionAMA.API.Filters;

public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomExceptionMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger, IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var error = new BasicResponse($"{ex.Message}");
            _logger.LogError(ex, ex.Message, error.Id);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            if (_environment.IsProduction())
                await context.Response.WriteAsync(JsonSerializer.Serialize(new BasicResponse(error.Id, "Ocurrió un error al procesar la solicitud")));
            else
                await context.Response.WriteAsync(JsonSerializer.Serialize(error));

        }
    }
}
