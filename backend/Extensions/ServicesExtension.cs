using backend.Entity;
using backend.Repositories.Contract;
using backend.Repositories;
using backend.Services.Contract;
using backend.Services;
using backend.Tools;
using Microsoft.EntityFrameworkCore;

namespace backend.Extensions
{
  public static class ServicesExtension
  {
    public static void DependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddControllers();

      services.AddDbContext<KazemarudbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("kazemarudb")));
      services.AddAutoMapper(typeof(AutoMapperProfile));

      services.AddScoped<IProjectRepository, ProjectRepository>();
      services.AddScoped<ITaskRepository, TaskRepository>();
      services.AddScoped<INoteRepository, NoteRepository>();
      services.AddScoped<IAppRepository, AppRepository>();

      services.AddScoped<IProjectService, ProjectService>();
      services.AddScoped<ITaskService, TaskService>();
      services.AddScoped<INoteService, NoteService>();
      services.AddScoped<IAppService, AppService>();

      services.AddCors(opts =>
      {
          opts.AddPolicy(name: "kazemaru-policy", builder =>
          {
              builder.AllowAnyHeader();
              builder.AllowAnyMethod();
              builder.WithOrigins(configuration.GetValue<string>("ClientOrigin") ?? "");
          });
      });
    }
  }
}
