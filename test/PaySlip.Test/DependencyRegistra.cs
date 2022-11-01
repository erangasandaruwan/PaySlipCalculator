using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaySlip.Core.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PaySlip.Test
{
    public class DependencyRegistra
    {
        public static IServiceCollection RegisterPaySlipServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(GetConfigurationRoot());
            return services;
        }

        public static IConfigurationRoot GetConfigurationRoot()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            Config.Configuration = configuration;
            return configuration;
        }
    }
}
