using backend.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KazemarudbContext>(opts =>
  opts.UseNpgsql(builder.Configuration.GetConnectionString("kazemarudb"))
);

var app = builder.Build();

app.Run();
