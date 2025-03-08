using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using TeamHorizon.ContentMigratorCli.Tasks;

namespace TeamHorizon.ContentMigratorCli.Commands
{
    public class PerformMigrateCommand : SubcommandBase<PerformMigrateTask, MigrateCommandArgs>
    {
        public PerformMigrateCommand(IServiceProvider container) : base("migrate", "Migrates content from source to target", container)
        {
            AddOption(ArgOptions.sourceEnvOption);
        }

        protected override async Task<int> Handle(PerformMigrateTask task, MigrateCommandArgs args)
        {
            await task.Execute(args).ConfigureAwait(false);
            return 0;
        }
    }
}
