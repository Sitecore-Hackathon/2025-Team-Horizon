using Microsoft.Extensions.Logging;
using Sitecore.DevEx.Client.Logging;
using TeamHorizon.ContentMigratorCli.Commands;

namespace TeamHorizon.ContentMigratorCli.Tasks
{
    public class PerformMigrateTask
    {
        private readonly ILogger<PerformMigrateTask> _logger;

        public PerformMigrateTask(ILogger<PerformMigrateTask> logger)
        {
            _logger = logger;
        }

        public async Task Execute(MigrateCommandArgs args)
        {
            ColorLogExtensions.LogConsole(_logger, LogLevel.Information, args.TargetEnvironment);
            ColorLogExtensions.LogConsole(_logger, LogLevel.Information, args.SourceEnvironment);
            ColorLogExtensions.LogConsole(_logger, LogLevel.Information, args.IncludeChildren.ToString());
            ColorLogExtensions.LogConsole(_logger, LogLevel.Information, args.RootItem);
        }

    }
}
