using BlazorBootstrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Registro_estudiantil___Tarea_1.Components;
using Registro_estudiantil___Tarea_1.DAL;
using Registro_estudiantil___Tarea_1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Obtener cadena de conexion para la bd local
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");
//Inyectar el contexto
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));
//Inyectar el servicio
builder.Services.AddScoped<EstudiantesService>();
builder.Services.AddScoped<AsignaturasService>();
//Agrega bootstrap
builder.Services.AddBlazorBootstrap();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
