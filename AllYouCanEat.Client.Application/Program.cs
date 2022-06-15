using AllYouCanEat.Client.Application;
using AllYouCanEat.Client.Core.Interfaces;
using AllYouCanEat.Client.Core.Services;
using AllYouCanEat.Client.Infrastructure.Repositories;
using AllYouCanEat.Client.QRCode.CodeOfTheDay.ServiceExtensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using QRCode.Core.LazyLoaded.ServiceCollectionExtensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddCodeOfTheDayServices();
builder.Services.AddLazyLoadedQRCodeServices();
builder.Services.AddScoped<IMilliwaysService, MilliwaysService>();
builder.Services.AddScoped<IMilliwaysRepository, MilliwaysRepository>();

await builder.Build().RunAsync();
