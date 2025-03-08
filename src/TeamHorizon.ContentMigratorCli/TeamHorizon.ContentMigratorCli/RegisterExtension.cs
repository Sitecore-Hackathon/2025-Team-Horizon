using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sitecore.Devex.Client.Cli.Extensibility;
using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using TeamHorizon.ContentMigratorCli.Commands;
using TeamHorizon.ContentMigratorCli.Tasks;

namespace TeamHorizon.ContentMigratorCli
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
