using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EventEaseApp;
using EventEaseApp.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Servicios propios
builder.Services.AddSingleton<EventService>();
builder.Services.AddSingleton<SessionService>(); // 👈 Nuevo servicio de sesión

await builder.Build().RunAsync();