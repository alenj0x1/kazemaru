using System.Text;
using Kazemaru.Application.Interfaces.Services;
using Kazemaru.Application.Mapping;
using Kazemaru.Application.Services;
using Kazemaru.Infrastructure.Persistence.Postgres.Context;
using Kazemaru.Infrastructure.Persistence.Postgres.Repositories;
using Kazemaru.WebApi.Middlewares;
using Kazemaru.WebApi.OpenApi.Transformers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using StackExchange.Redis;

namespace Kazemaru.WebApi.Extensions;

public static class ServiceCollectionExtension
{
    public static async void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .Enrich.WithEnvironmentName()
                .Enrich.WithProcessId()
                .Enrich.WithProcessName()
                .CreateLogger();
            
            services.AddControllers();

            services.AddDbContext<KazemaruDbContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("Postgres") ??
                              throw new Exception("Missing Postgres Connection String")));

            services.AddSingleton<IConnectionMultiplexer>(sp =>
                ConnectionMultiplexer.Connect(configuration.GetConnectionString("redis") ??
                                              throw new Exception("Missing Redis Connection String")));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddAuthentication(builder =>
            {
                builder.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                builder.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(builder =>
            {
                builder.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"] ??
                                  throw new Exception("Missing JWT Issuer"),
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"] ??
                                    throw new Exception("Missing JWT Audience"),
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        configuration["Jwt:SecretKey"] ??
                        throw new Exception("Missing JWT Secret Key"))),
                    ValidateLifetime = true
                };
                builder.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        var accessToken = context.Request.Headers.Authorization.ToString()["Bearer ".Length..].Trim();
                        if (string.IsNullOrEmpty(accessToken))
                        {
                            context.Fail("token invalid");
                            return;
                        }

                        var tokenService = context.HttpContext.RequestServices.GetRequiredService<ITokenService>();

                        var findAccessToken = await tokenService.GetAccessTokenAsync(accessToken);
                        if (findAccessToken is null)
                        {
                            context.Fail("token invalid");
                        }
                    }
                };
            });

            services.AddAuthorization();

            services.AddScoped<ErrorHandlerMiddleware>();

            services.AddScoped<ProjectRepository>();
            services.AddScoped<TaskRepository>();
            services.AddScoped<NoteRepository>();
            services.AddScoped<AppRepository>();
            services.AddScoped<UserRepository>();

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IAppService, AppService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddCors(opts =>
            {
                opts.AddPolicy(name: "kazemaru-policy", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowCredentials();
                    builder.WithOrigins(configuration.GetValue<string>("ClientOrigin") ?? "");
                });
            });
            
            services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
                options.AddDocumentTransformer<ConfigureDocumentTransformer>();
            });

            // First user creation
            await using var scope = services.BuildServiceProvider();
            var userService = scope.GetRequiredService<IUserService>();
            await userService.FirstUser();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}