var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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


/*
AVANCE DEL PROYECTO:

Parte 1: Creación del proyecto 24/01/2025 20:00 pm

Parte 2: Modelado y creación de las bases de datos 00/01/2025 00:00 
Creación de Entidades (Clases) 
Instalación de paquetes NuGet 
Creación de Contexto y modelado para la base de datos 
Relaciones entre tablas 
Conexión a la base de datos 
Generación de migraciones para la base de datos

Parte 3: API Básico: Crear Api Controlador - Perfil 00/01/2025 00:00 
Creación del controlador
 Métodos Http Get 
 Creación de DTO para manejo de información precisa

Parte 4: API Solicitudes HTTP: Crear Api Controlador - Empleado 00/01/2025 00:00 
Creación de métodos faltantes 
Creación de servicios, para evitar demasiada lógica en los controladores

Finalización del proyecto 00/01/2025 00:00
*/