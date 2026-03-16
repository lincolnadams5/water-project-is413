using Microsoft.EntityFrameworkCore;
using WaterProject.api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<WaterDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("WaterConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
}); // Tells dotnet that we want to allow CORS requests from any origin, with any method and any header.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(x => x.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader()); // Tells dotnet to use the CORS policy we defined above, but only for requests coming from http://localhost:5150 (the React frontend).

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
