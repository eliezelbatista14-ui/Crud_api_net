using GestorAlquiler.API.Data;
using GestorAlquiler.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -----------------------------------------
// HABILITAR CORS PARA BLAZOR
// -----------------------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy =>
        {
            policy.WithOrigins("https://localhost:7093")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// -----------------------------------------
// PASO 8: REGISTRAR DBCONTEXT
// -----------------------------------------
builder.Services.AddDbContext<GestorAlquilerApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// -----------------------------------------
// PASO 8: REGISTRAR REPOSITORIOS
// -----------------------------------------
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowBlazor");

app.UseAuthorization();

app.MapControllers();

app.Run();
