using Microsoft.EntityFrameworkCore;
using Proyecto2026WA.BD.Datos;
using Proyecto2026WA.Repositorio;

var builder = WebApplication.CreateBuilder(args);

#region Servicios
var connectionString = builder.Configuration
                    .GetConnectionString("connSql") ??
                    throw new InvalidOperationException("La conexión a la base de datos no funciona.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IPaisRepositorio, PaisRepositorio>();

#endregion

var app = builder.Build();

#region Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
#endregion

app.Run();
