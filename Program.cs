using inyeccion_dependencias_ejercicios.ConDY;
using inyeccion_dependencias_ejercicios.DataContext;
using inyeccion_dependencias_ejercicios.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContextNorthwind>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind"));
});

builder.Services.AddTransient<UsuarioServiceConDY>();
builder.Services.AddTransient<IEmailServiceConDY, EmailServiceConDY>();
builder.Services.AddTransient<INorthwindRepository, NorthwindRepository>();
builder.Services.AddSwaggerGen();

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
