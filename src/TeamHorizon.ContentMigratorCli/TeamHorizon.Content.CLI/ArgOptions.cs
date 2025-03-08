using System.CommandLine;

namespace TeamHorizon.Content.CLI
{
    internal static class ArgOptions
    {
        internal static readonly Option<string>
            sourceEnvOption       = new Option<string>(
                "--source-env",
                "The source XM Cloud environment to migrate content from");

        internal static readonly Option<string>
            targetEnvOption       = new Option<string>(
                "--target-env",
                "The target XM Cloud environment to migrate content to");
        internal static readonly Option<string> 
            rootItemOption        = new Option<string>(
                "--root-item",
                "The path to the root item to migrate (e.g. /sitecore/content/home)");
        internal static readonly Option<bool> 
            includeChildrenOption = new Option<bool>(
                "--include-children",
                ()                => true,
                "Include children of the root item");
    }
}
