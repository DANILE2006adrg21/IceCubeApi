using Microsoft.EntityFrameworkCore;
using IceCube.Context; // 👈 este debe apuntar al namespace donde está tu DbContext

var builder = WebApplication.CreateBuilder(args);

// Configurar Entity Framework con SQL Server
builder.Services.AddDbContext<IceCube_Apicontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IceCubeContext")
        ?? throw new InvalidOperationException("Connection string 'IceCubeContext' not found.")));


// Agregar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar pipeline HTTP
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

// 🔹 Endpoint opcional para probar la conexión a la BD
app.MapGet("/health/db", async (IceCube_Apicontext db) =>
    await db.Database.CanConnectAsync()
        ? Results.Ok("✅ Conexión correcta con la base de datos IceCube")
        : Results.Problem("❌ No se pudo conectar con la base de datos"));

app.Run();
