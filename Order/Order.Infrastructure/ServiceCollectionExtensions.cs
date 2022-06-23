using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using Order.Core.Interfaces;
using Order.Core.Services;
using Order.Infrastructure.Repositories;

namespace Order.Infrastructure; 
public static class ServiceCollectionExtensions {
    public static IServiceCollection AddOrderServices(this IServiceCollection services) {
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<IProductsService, ProductsService>();
        
        services.AddBlazoredLocalStorage();

        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<IBasketRepository, BasketRepository>();

        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        return services;
    }
}
