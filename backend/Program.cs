using backend.Extensions;
using backend.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.DependencyInjection(builder.Configuration);

var app = builder.Build();

app.UseCors("kazemaru-policy");

app.Map("/", () => new { msg = "kazemaru api" });
app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
