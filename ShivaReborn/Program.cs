using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using ShivaReborn.Business;
using ShivaReborn.Business.Interfaces;
using ShivaReborn.DataAccess;
using ShivaReborn.DataAccess.Models;
using ShivaReborn.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IService<User>, UserService>();
builder.Services.AddTransient<IRepository<User>, UserRepository>();
builder.Services.AddTransient<IService<Floor>, FloorService>();
builder.Services.AddTransient<IRepository<Floor>, FloorRepository>();
builder.Services.AddTransient<IService<Place>, PlaceService>();
builder.Services.AddTransient<IRepository<Place>, PlaceRepository>();
builder.Services.AddTransient<IService<Building>, BuildingService>();
builder.Services.AddTransient<IRepository<Building>, BuildingRepository>();


var connectionString = builder.Configuration.GetConnectionString("ShivaContext");
builder.Services.AddDbContext<ShivaContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddCors(options =>
{
    options.AddPolicy("ShivaCorsPolicy", builder =>
    {
        builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("ShivaCorsPolicy");

app.MapControllers();

app.Run();
