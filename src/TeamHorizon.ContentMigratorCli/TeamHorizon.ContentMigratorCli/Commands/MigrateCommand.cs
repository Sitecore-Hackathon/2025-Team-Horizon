
using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using System.CommandLine;

namespace TeamHorizon.ContentMigratorCli.Commands
{
    public class MigrateCommand : Command, ISubcommand
    {
        public MigrateCommand(string name, string description = null) : base(name, description)
        {
        }
    }
}