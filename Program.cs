using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EventEaseApp;
using EventEaseApp.Data;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Servicios propios
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

var host = builder.Build();

// Inicializar sesión desde localStorage
var sessionService = host.Services.GetRequiredService<SessionService>();
await sessionService.InitializeAsync();

// Inicializar eventos desde localStorage
var eventService = host.Services.GetRequiredService<EventService>();
await eventService.InitializeAsync();

await host.RunAsync();