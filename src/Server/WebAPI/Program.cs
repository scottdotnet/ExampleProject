using ExampleProject.Server.Application;
using ExampleProject.Server.Infrastructure;
using ExampleProject.Server.Infrastructure.Persistance;
using ExampleProject.Server.WebAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddWebAPI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

await context.Database.MigrateAsync();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }