using System.Text;
using Microsoft.EntityFrameworkCore;
using ShivaReborn.Business;
using ShivaReborn.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var configuration = builder.Configuration;

app.MapGet("/", () => "Hello World!");

var services = builder.Services;

services.AddControllersWithViews().AddNewtonsoftJson();
services.AddRazorPages();

services.AddCors(options =>
{
    options.AddPolicy("JudgeAppCorsPolicy", builder =>
    {
        builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

app.Run();