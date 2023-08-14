// Copyright (c) SharpCrafters s.r.o. See the LICENSE.md file in the root directory of this repository root for details.

using PostSharp.Engineering.BuildTools;
using PostSharp.Engineering.BuildTools.Build.Model;
using PostSharp.Engineering.BuildTools.Build.Solutions;
using PostSharp.Engineering.BuildTools.Dependencies.Definitions;
using Spectre.Console.Cli;
using Dependencies = PostSharp.Engineering.BuildTools.Dependencies.Definitions.TemplateDependencies;

var product = new Product( Dependencies.MyProduct )
{
    Solutions = new Solution[]
    {
        new DotNetSolution( "src\\My.Product.sln" )
    },
    PublicArtifacts = Pattern.Create( "My.Product.$(PackageVersion).nupkg" ),
    Dependencies = new[] { DevelopmentDependencies.PostSharpEngineering, MetalamaDependencies.V2023_3.Metalama }
};

var commandApp = new CommandApp();

commandApp.AddProductCommands( product );

return commandApp.Run( args );