using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.IO;
using NLog;
using Microsoft.OpenApi.Models;
using PaySlip.Application.Extension;
using PaySlip.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using PaySlip.Application.Command;
using PaySlip.Core.Util;

namespace PaySlip.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Config.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure logger
            services.ConfigureLogger();

            // Configure services
            services.ConfigureServiceBehaviours();

            // Configure repos
            services.ConfigureRepositores();

            services.AddControllers();

            // Configure auto mapper 
            services.AddAutoMapper(typeof(Startup));

            // Configure mediator
            services.AddMediatR(typeof(PaySlipCalculate).GetTypeInfo().Assembly);

            // Configure cache
            services.ConfigureCaching();

            // Configure db connectivity
            services.AddDbContext<PaySlipDbContext>(options =>
            {
                options.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning))
                    .UseSqlServer(Configuration["PaySlipDbContext"],
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(3),
                        errorNumbersToAdd: null);
                    sqlOptions.MigrationsAssembly("PaySlip.DbMigration");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaySlip.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaySlip.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(policy =>
                policy.WithOrigins("http://localhost:4200")
                      .AllowAnyMethod()
                      .AllowAnyHeader());

            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
