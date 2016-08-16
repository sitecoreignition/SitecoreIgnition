# Sitecore Ignition

Ignition is an open source development accelerator designed by the team at [Perficient](http://www.perficient.com) and released to the Sitecore community as a quick-start tool for beginning Sitecore projects. It has two primary components: the Sitecore Information Architecture piece and the .NET MVC Solution. All along the way, the team has set things up so that we're using best practices for Sitecore development as well as good development practices and patterns. We embrace SOLID, and our code is designed to enable you, the consumer, to quickly extend, add onto, and test your own code.

Please note that Ignition is in beta and may still be a bit rough around the edges. We are diligently adding new features and polish to the project and we happily accept your thoughts, feature requests, and pull requests.

## Get Started

1. Setup a new Sitecore install on your machine.
2. By default, Ignition uses `http:\\ignition.localhost` as the URL. Add this URL to your hosts file and add it to your site's IIS bindings.
3. Clone the repository: `git clone https://github.com/sitecoreignition/SitecoreIgnition.git`.
4. Copy the following Sitecore .dlls into the `_lib` folder:
	* `Sitecore.ContentSearch.dll`
	* `Sitecore.ContentSearch.Linq.dll`
	* `Sitecore.Kernel.dll`
	* `Sitecore.Mvc.dll`
	* `Sitecore.Client.dll`
5. Update App_Config/Include/Folder.config file in `Ignition.Root` project to set the dataFolder and solutionFolder variables to your local data/solution folder paths.

### If You Have [Team Development for Sitecore](https://www.teamdevelopmentforsitecore.com/)

6. Open the solution `Ignition.Tds.sln`.
7. Do a full build.
8. Sync `Ignition.Root.TDS.Master` with TDS.
9. Sync `Ignition.Sc.TDS.Master` with TDS.
10. Open Sitecore, publish your site, and have fun!

### If You Use [Unicorn](https://github.com/kamsar/Unicorn) 
6. Open the solution `Ignition.Unicorn.sln`.
7. Create a publishing profile called `Ignition.Sc` in the `Ignition.Sc` project.
8. Create a publishing profile called `Ignition.Root` in the `Ignition.Root` project.
9. Create a publishing profile called `Ignition.Unicorn` in the `Ignition.Unicorn` project.
10. Publish `Ignition.Sc`, then `Ignition.Root`, then `Ignition.Core.Unicorn`.
11. Navigate to the [Unicorn Control Panel](http://ignition.localhost/unicorn.aspx) and sync the two Ignition configurations.
12. Publish your site and have fun!

### If you don't have either TDS or Unicorn

6. Open the solution `Ignition.sln`.
7. Create a publishing profile called `Ignition.Sc` in the `Ignition.Sc` project.
8. Create a publishing profile called `Ignition.Root` in the `Ignition.Root` project.
9. Publish `Ignition.Sc` and then publish `Ignition.Root`.
10. Navigate to the [Update Installation Wizard](http://ignition.localhost/sitecore/admin/updateinstallationwizard.aspx) and install the update packages found in the `SitecorePackages` folder.
11. Publish your site and have fun!

Ignition has been tested using Sitecore 8.0 Update-4 and above. Ignition probably works with any version of the Sitecore 7 and 8 .dlls but we have not confirmed.

## Solution Structure

### Core

#### Ignition.Core

Innermost library accessible to the entire solution that houses core functionality used in other layers.

### Data

#### Ignition.Data

Includes standard models used by the framework. This is where you'll add your own shared models.

### Infrastructure

#### Ignition.Infrastructure

Integration layer where Ignition interacts with Sitecore (e.g., pipeline events, commands, etc.) and external integrations.

### Presentation

Presentation layer. Add your Sitecore site here.

#### Ignition.Sc

Demo Ignition site. Examples and reusable components.

### Root

#### Ignition.Root

Composition root for the solution. Where IoC container, Glass Mapper, and MVC are configured and initialized.

## Community

* Follow [@ignition_sc on Twitter](https://twitter.com/ignition_sc).
* Join the Ignition channel on [the Sitecore Community Slack](https://sitecorechat.slack.com).

## Copyright and License

Code and documentation copyright 2016 Jon Upchurch and Perficient, Inc. released under [the MIT license](https://github.com/sitecoreignition/SitecoreIgnition/blob/master/LICENSE).
