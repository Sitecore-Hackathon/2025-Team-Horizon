namespace TeamHorizon.ContentMigratorCli.Commands
{
    public class MigrateCommandArgs
    {
        public string SourceEnvironment { get; set; }
        public string TargetEnvironment { get; set; }
        public string RootItem { get; set; }
        public bool IncludeChildren { get; set; }
    }
}
