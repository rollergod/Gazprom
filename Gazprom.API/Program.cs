using Gazprom.API.Infrastructure;
using Gazprom.API.Repositories;
using Gazprom.API.Service;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IOfferService, OfferService>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("front", policy => policy.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader());
});


builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseCors("front");

app.UseAuthorization();
app.MapControllers();
app.Run();