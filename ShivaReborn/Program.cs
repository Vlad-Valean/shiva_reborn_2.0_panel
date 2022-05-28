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

var connectionString = builder.Configuration.GetConnectionString("ShivaContext");
builder.Services.AddDbContext<ShivaContext>(options => options.UseNpgsql(connectionString,x => x.MigrationsAssembly("ShivaReborn.DataAccess")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();