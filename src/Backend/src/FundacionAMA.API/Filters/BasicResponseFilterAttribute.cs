using FundacionAMA.Application.DTO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System.Net;

namespace FundacionAMA.API.Filters;

public class BasicResponseFilterAttribute : ActionFilterAttribute
{
    private readonly HashSet<int> ErrorStatusCodes = new HashSet<int>
    {
        (int)HttpStatusCode.InternalServerError,
        (int)HttpStatusCode.BadGateway,
        (int)HttpStatusCode.RequestTimeout
    };

    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is ObjectResult objectResult)
        {
            if (ErrorStatusCodes.Contains(context.HttpContext.Response.StatusCode))
            {
                var errorMessage = objectResult.Value is ProblemDetails problemDetails ? problemDetails.Detail : "Ocurrió un error al procesar la solicitud";
                objectResult.Value = new BasicResponse(errorMessage ?? "Ocurrió un error al procesar la solicitud");
            }

            if (objectResult.StatusCode == (int)HttpStatusCode.Unauthorized && context.HttpContext.Request.Path != "/api/Auth")
            {
                objectResult.Value = new BasicResponse("No tiene permisos para realizar esta acción");
            }

        }

        base.OnResultExecuting(context);
    }
}
