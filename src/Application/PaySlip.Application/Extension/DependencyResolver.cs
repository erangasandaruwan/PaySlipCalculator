using Microsoft.Extensions.DependencyInjection;
using PaySlip.Application.Core.Log;
using PaySlip.Core.Cache;
using PaySlip.Core.Data;
using PaySlip.Domain.Infrastructure.Repository;
using PaySlip.Domain.ServiceBehaviour;

namespace PaySlip.Application.Extension
{
    public static class DependencyResolver
    {
        public static IServiceCollection ConfigureLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            return services;
        }

        public static IServiceCollection ConfigureServiceBehaviours(this IServiceCollection services)
        {
            services.AddTransient<IPaySlipCalculateService, PaySlipCalculateService>();
            return services;
        }

        public static IServiceCollection ConfigureRepositores(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddTransient<ITaxRateRepository, TaxRateRepository>();
            return services;
        }

        public static IServiceCollection ConfigureCaching(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton(typeof(IModelCache<,>), typeof(ModelInMemoryCache<,>));
            return services;
        }
    }
}
