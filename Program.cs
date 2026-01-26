using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EventEaseApp;
using EventEaseApp.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Registrar EventService como Singleton
builder.Services.AddSingleton<EventService>();

await builder.Build().RunAsync();
