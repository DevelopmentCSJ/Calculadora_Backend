using Calculadora.Core.Interfaces;
using Calculadora.Core.Interfaces.Servicios;
using Calculadora.Core.Servicios;
using Calculadora.Infraestructura.Data;
using Calculadora.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy => policy.AllowAnyOrigin());
});

builder.Services.AddDbContext<CalculadoraContext>(options =>
    options.UseSqlServer("Server=SV01003-UDAPP01;Initial Catalog=calculadora;Integrated Security=True;MultipleActiveResultSets=False;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddScoped<ICalculadoraServicio, CalculadoraServicio>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials

app.MapControllers();

app.Run();
