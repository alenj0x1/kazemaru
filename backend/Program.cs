using backend.Entity;
using backend.Repositories;
using backend.Repositories.Contract;
using backend.Services;
using backend.Services.Contract;
using backend.Tools;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<KazemarudbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("kazemarudb")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();

var app = builder.Build();

app.Map("/", () => new { msg = "kazemaru api" });

app.MapControllers();

app.Run();
