using Forums.API.Models;
using System.Net;
namespace Forums.API.Middleware;

public class ErrorHandlingMiddleware
{
    private RequestDelegate _next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {

            await HandleExeptionAsync(context, ex);
        }
    }

    private Task HandleExeptionAsync(HttpContext context, Exception ex)
    {
        CommonResponse apiResponse = new();
        switch(ex)
        {
            case ArgumentException:
                apiResponse.Message = ex.Message;
                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.BadRequest;
                break;
        }
        context.Response.ContentType = "application/json";
        context.Response.StatusCode=Convert.ToInt32(apiResponse.StatusCode);

        return context.Response.WriteAsJsonAsync(apiResponse);
    }
}
