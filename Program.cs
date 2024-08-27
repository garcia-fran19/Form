using MudBlazor.Services;
using Form.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using Form.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Registrar HttpClient con una dirección base
builder.Services.AddScoped<HttpClient>(sp =>
{
    var client = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7049/") // Ajusta la URL base según tu API
    };
    return client;
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql("Server=127.0.0.1;Port=3306;Database=formget;User=root;Password=root;",
                     new MySqlServerVersion(new Version(8, 0, 0))));

// Agregar servicios al contenedor.
builder.Services.AddControllers(); // Esta línea agrega soporte para los controladores.

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.UseRouting();
app.MapControllers(); // Esta línea habilita el routing a los controladores.



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
