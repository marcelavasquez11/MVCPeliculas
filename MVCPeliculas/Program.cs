using Microsoft.EntityFrameworkCore;
using MVCPeliculas.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PeliculasDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// SeedData desactivado temporalmente para el despliegue
// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     SeedData.Initialize(services);
// }

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "saludar",
    pattern: "{controller}/{action}/{nombre}/{id}");

app.Run();