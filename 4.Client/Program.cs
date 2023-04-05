using _4.Client;
using _4.Client.IServices;
using _4.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddTransient<IAllServices, AllServices>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7111") });
//liên k?t v?i api

await builder.Build().RunAsync();
