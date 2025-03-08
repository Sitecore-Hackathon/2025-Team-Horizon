using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using Sitecore.Devex.Client.Cli.Extensibility;
using System;
using System.Collections.Generic;
using TeamHorizon.Content.CLI.Commands;
using TeamHorizon.Content.CLI.Tasks;
using Microsoft.Extensions.Logging;

namespace TeamHorizon.Content.CLI
{
    public class RegisterExtension : ISitecoreCliExtension
    {
        public IEnumerable<ISubcommand> AddCommands(IServiceProvider container)
        {
            var migrateCommand = new MigrateCommand("migrate", "Migrates content from source to target");
            migrateCommand.AddCommand(container.GetRequiredService<PerformMigrateCommand>());

            return new ISubcommand[]
            {
                migrateCommand
            };
        }

        public void AddConfiguration(IConfigurationBuilder configBuilder)
        {

        }

        public void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<PerformMigrateCommand>()
                .AddSingleton(sp => sp.GetService<ILoggerFactory>().CreateLogger<PerformMigrateTask>());
        }
    }
}
