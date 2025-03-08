using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using System.CommandLine;

namespace TeamHorizon.Content.CLI.Commands
{
    public class MigrateCommand : Command, ISubcommand
    {
        public MigrateCommand(string name, string description = null) : base(name, description)
        {
        }
    }
}
