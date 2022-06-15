using AllYouCanEat.Client.QRCode.CodeOfTheDay.Core.Interfaces;
using AllYouCanEat.Client.QRCode.CodeOfTheDay.Core.Services;
using AllYouCanEat.Client.QRCode.CodeOfTheDay.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AllYouCanEat.Client.QRCode.CodeOfTheDay.ServiceExtensions;
public static class ServiceExtensions {
    public static IServiceCollection AddCodeOfTheDayServices(this IServiceCollection services) {
        services.AddScoped<ICodeOfTheDayService, CodeOfTheDayService>();
        services.AddScoped<ICodeOfTheDayRepository, CodeOfTheDayRepository>();
        return services;
    }
}
