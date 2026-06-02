using Microsoft.EntityFrameworkCore;
using Proyecto2026WA.BD.Datos;

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
#endregion

var app = builder.Build();

#region Middleware
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
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
