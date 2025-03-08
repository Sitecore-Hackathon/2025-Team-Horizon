using Microsoft.Extensions.DependencyInjection;
using ScExtensions.ContentMigration.Commands;
using ScExtensions.ContentMigration.Services;
using Sitecore.Cli.Core.Extensibility;
using System;

namespace ScExtensions.ContentMigration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddContentMigrationPlugin(this IServiceCollection services)
        {
            // Register the command
            services.AddSingleton<ISitecoreCliCommand, MigrateCommand>();

            // Register services
            services.AddHttpClient<XmCloudContentService>()
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    UseCookies = false
                });

            return services;
        }
    }
}
