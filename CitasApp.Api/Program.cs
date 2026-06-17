using CitasApp.Application.Services;
using CitasApp.Domain.Interfaces;
using CitasApp.Infrastructure.Helpers;
using CitasApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

#region SERVICES (DEPENDENCY INJECTION)

// Controllers
builder.Services.AddControllers();

// JsonDataService
builder.Services.AddScoped<JsonDataService>(sp =>
    new JsonDataService(
        Path.Combine(Directory.GetCurrentDirectory(), "Data")
    ));

// Repositorios
builder.Services.AddScoped<IPacienteRepository, JsonPacienteRepository>();
builder.Services.AddScoped<IMedicoRepository, JsonMedicoRepository>();
builder.Services.AddScoped<ICitaRepository, JsonCitaRepository>();

// Servicios de aplicación
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<CitaService>();

// CORS (PERMITE HTML EXTERNO)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

#endregion

var app = builder.Build();

#region MIDDLEWARE PIPELINE

// ⚠️ 1. HTTPS REDIRECTION
app.UseHttpsRedirection();

// ⚠️ 2. CORS (DEBE IR AQUÍ, ANTES DE AUTH Y CONTROLLERS)
app.UseCors("AllowAll");

// ⚠️ 3. ARCHIVOS ESTÁTICOS (si usas wwwroot)
app.UseDefaultFiles();
app.UseStaticFiles();

// ⚠️ 4. AUTHORIZATION (aunque no la uses aún)
app.UseAuthorization();

// ⚠️ 5. MAP CONTROLLERS (API ENDPOINTS)
app.MapControllers();

#endregion

app.Run();