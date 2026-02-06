using Kazemaru.WebApi.Extensions;
using Kazemaru.WebApi.Middlewares;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/api-reference", options =>
    {
        options.Title = "Kazemaru - API Reference";
        options.Theme = ScalarTheme.Alternate;
        options.Authentication = new ScalarAuthenticationOptions
        {
            PreferredSecuritySchemes = ["Bearer"]
        };
    });
}

app.UseCors("kazemaru-policy");

app.Map("/", () => new { msg = "kazemaru api" });
app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.Run();