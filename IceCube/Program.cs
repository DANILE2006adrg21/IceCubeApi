using Microsoft.EntityFrameworkCore;
using IceCube.Context; // 👈 DbContext

var builder = WebApplication.CreateBuilder(args);

// 🔹 1. DbContext con tu connection string
builder.Services.AddDbContext<IceCube_Apicontext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("IceCubeContext")
        ?? throw new InvalidOperationException("Connection string 'IceCubeContext' not found.")
    )
);

// 🔹 2. CORS (MUY IMPORTANTE para Android / Render)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// 🔹 3. Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 4. Swagger (puedes limitar a Development si quieres)
app.UseSwagger();
app.UseSwaggerUI();

// 🔹 5. CORS antes de los controladores
app.UseCors("AllowAll");

// (Si algún día usas auth con JWT, aquí iría: app.UseAuthentication();)
app.UseAuthorization();

app.MapControllers();

// 🔹 6. Endpoint de prueba de conexión a la BD (healthcheck)
app.MapGet("/health/db", async (IceCube_Apicontext db) =>
    await db.Database.CanConnectAsync()
        ? Results.Ok("✅ Conexión correcta con la base de datos IceCube")
        : Results.Problem("❌ No se pudo conectar con la base de datos"));

// 🔹 7. Run
app.Run();


