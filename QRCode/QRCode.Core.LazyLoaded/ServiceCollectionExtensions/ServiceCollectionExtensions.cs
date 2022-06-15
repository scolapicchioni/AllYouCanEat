using Microsoft.Extensions.DependencyInjection;
using QRCode.Core.LazyLoaded.Repositories;
using QRCode.Core.LazyLoaded.Services;

namespace QRCode.Core.LazyLoaded.ServiceCollectionExtensions {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddLazyLoadedQRCodeServices(this IServiceCollection services) {
            services.AddScoped<IQRCodeServiceFactory , QRCodeServiceFactory>();
            services.AddScoped<IQRCodeRepositoryFactory, QRCodeRepositoryFactory>();
            return services;
        }
    }
}
