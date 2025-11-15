using GestorAlquiler.API.Data;
using GestorAlquiler.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -----------------------------------------
// HABILITAR CORS PARA BLAZOR WEBASSEMBLY
// -----------------------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy =>
        {
            policy.WithOrigins("https://localhost:7093") // URL de tu Blazor WASM
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Configurar EF Core
builder.Services.AddDbContext<GestorAlquilerApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyectar repositorio
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// -----------------------------------------
// ACTIVAR CORS ANTES DE MapControllers()
// -----------------------------------------
app.UseCors("AllowBlazor");

app.UseAuthorization();

app.MapControllers();

app.Run();
