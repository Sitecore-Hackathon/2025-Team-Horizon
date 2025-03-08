# Hackathon Submission Entry form

> __Important__  
> 
> Copy and paste the content of this file into README.md or face automatic __disqualification__  
> All headlines and subheadlines shall be retained if not noted otherwise.  
> Fill in text in each section as instructed and then delete the existing text, including this blockquote.

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

## Team name
Team Horizon

## Category
⟹CLI Customization

## Description
⟹ Write a clear description of your hackathon entry.  

  - Make XMCloud Content Hydrations a breeze with a single command!
  - Hydration of content between environments in the same instance or multiple could be a very challenging experience for the Team.
    - With a single CLI command, we can hydrate content based on pre-defined module configurations between environments.
    - E.g. Prod -> QA, QA -> Dev

_You can alternately paste a [link here](#docs) to a document within this repo containing the description._

## Video link
⟹ Provide a video highlighing your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_

⟹ [Replace this Video link](#video-link)

## Pre-requisites and Dependencies

⟹ Does your module rely on other Sitecore modules or frameworks?

- Sitecore XMCloud access.
- Or other modules that must be installed
- Or services that must be enabled/configured

_Remove this subsection if your entry does not have any prerequisites other than Sitecore_

## Installation instructions
⟹ Write a short clear step-wise instruction on how to install your module.  

## Installing the Extension

1. **Install the extension to your Sitecore CLI**:

```shellscript
dotnet sitecore plugin add -f ./output/ScExtensions.ContentMigration.1.0.0.nupkg
```

2. **Verify the installation**:
```shellscript
dotnet sitecore --help
```
## Usage

Thought for 2 seconds### Building and Using the Sitecore CLI Content Migration Extension

Here's a detailed guide on how to build and use the content migration command:

## Prerequisites

- .NET 6.0 SDK or later
- Sitecore CLI installed (`dotnet tool install -g Sitecore.CLI`)
- Access to Sitecore XM Cloud environments


## Building the Extension

1. **Clone or create the project structure** as shown in the code above
2. **Navigate to the project directory**:

```shellscript
cd ScExtensions.ContentMigration
```


3. **Build the project**:

```shellscript
dotnet build
```


4. **Pack the extension into a NuGet package**:

```shellscript
dotnet pack -o ./output
```

This will create a `.nupkg` file in the `./output` directory.




## Installing the Extension

1. **Install the extension to your Sitecore CLI**:

```shellscript
dotnet sitecore plugin add -f ./output/ScExtensions.ContentMigration.1.0.0.nupkg
```


2. **Verify the installation**:

```shellscript
dotnet sitecore --help
```

You should see the `migrate` command listed in the available commands.


## Authenticating with XM Cloud

Before using the migration command, you need to authenticate with both XM Cloud environments:

1. **Authenticate with the source environment**:

```shellscript
dotnet sitecore login --authority https://auth.sitecore.io --cm https://xmc-source-env.sitecoredemo.com
```


2. **Authenticate with the target environment**:

```shellscript
dotnet sitecore login --authority https://auth.sitecore.io --cm https://xmc-target-env.sitecoredemo.com
```

## Using the Migrate Command

Now you can use the migrate command to transfer content:

```shellscript
dotnet sitecore migrate --source-env "https://xmc-source-env.sitecoredemo.com" --target-env "https://xmc-target-env.sitecoredemo.com" --root-item "/sitecore/content/home" --include-children true
```

### Command Parameters

- `--source-env`: The URL of the source XM Cloud environment
- `--target-env`: The URL of the target XM Cloud environment
- `--root-item`: The path to the item you want to migrate
- `--include-children`: Whether to include child items (default is true)


## Example Scenarios

### Migrating a Single Page

```shellscript
dotnet sitecore migrate --source-env "https://xmc-source-env.sitecoredemo.com" --target-env "https://xmc-target-env.sitecoredemo.com" --root-item "/sitecore/content/home/about-us" --include-children false
```

### Migrating an Entire Site

```shellscript
dotnet sitecore migrate --source-env "https://xmc-source-env.sitecoredemo.com" --target-env "https://xmc-target-env.sitecoredemo.com" --root-item "/sitecore/content/home" --include-children true
```

### Migrating Media Items

```shellscript
dotnet sitecore migrate --source-env "https://xmc-source-env.sitecoredemo.com" --target-env "https://xmc-target-env.sitecoredemo.com" --root-item "/sitecore/media library/images" --include-children true
```


### Configuration
⟹ If there are any custom configuration that has to be set manually then remember to add all details here.

_Remove this subsection if your entry does not require any configuration that is not fully covered in the installation instructions already_

## Usage instructions
⟹ Provide documentation about your module, how do the users use your module, where are things located, what do the icons mean, are there any secret shortcuts etc.

Include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:

![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")

You can embed images of different formats too:

![Deal With It](docs/images/deal-with-it.gif?raw=true "Deal With It")

And you can embed external images too:

![Random](https://thiscatdoesnotexist.com/)

## Comments
If you'd like to make additional comments that is important for your module entry.
