using Microsoft.EntityFrameworkCore;
using apiStarWarsProject.Context;
using apiStarWarsProject.Services;
using apiStarWarsProject;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Relacion de cadena de conexion
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexionDB"))
);

//Inicia uso de servicios
builder.Services.AddScoped<ArmyDivisionService>();
builder.Services.AddScoped<TrooperRankService>();
builder.Services.AddScoped<TrooperStatusService>();
builder.Services.AddScoped<JediRankService>();
builder.Services.AddScoped<JediService>();
builder.Services.AddScoped<CloneTrooperService>();
// Fin de uso de servicios

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


/*
AVANCE DEL PROYECTO:

Parte 1: Creación del proyecto 24/01/2025 20:00 pm

Parte 2: Modelado y creación de las bases de datos 25/01/2025 17:33 
    Creación de Entidades (Clases) 
    Instalación de paquetes NuGet 
    Creación de Contexto y modelado para la base de datos 
    Conexión a la base de datos 
    Generación de migraciones para la base de datos

Parte 3: Crear Api Controlador 
    Creación del controlador
    Creación de DTO para manejo de información precisa

Parte 4: API Solicitudes HTTP: Crear Api Controlador - 
Creación de servicios,

Finalización del proyecto 29/01/2025 19:02
*/