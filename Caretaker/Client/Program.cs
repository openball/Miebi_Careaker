global using Caretaker.Client.Services.PersonService;
global using Caretaker.Client.Services.ApartmentTypeService;
global using Caretaker.Shared;
using Caretaker.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IApartmentTypeService, ApartmentTypeService>();

await builder.Build().RunAsync();
