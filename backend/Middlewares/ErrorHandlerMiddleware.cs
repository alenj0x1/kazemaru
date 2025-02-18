using backend.Helpers;

namespace backend.Middlewares;

public class ErrorHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            var response = ManageResponse.Create(string.Empty, e.Message, false);

            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}