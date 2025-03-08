using Microsoft.Extensions.DependencyInjection;
using Sitecore.Cli.Core.Extensibility;
using System;

namespace ScExtensions.ContentMigration
{
    public class PluginConfiguration : IPluginConfiguration
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddContentMigrationPlugin();
        }
    }
}
