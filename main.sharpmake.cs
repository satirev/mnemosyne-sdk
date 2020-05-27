// Copyright (c) 2020 Mnemosyne

using Sharpmake;

[module: Include("src/sdk/sdk.sharpmake.cs")]
[module: Include("src/sdkUnitTests/sdkUnitTests.sharpmake.cs")]

namespace MnemosyneSdk
{
    abstract public class BaseProject : Project
    {
        public BaseProject()
        {
            AddTargets(new Target(
                Platform.win64,
                DevEnv.vs2019,
                Optimization.Debug | Optimization.Release,
                OutputType.Dll
            ));

            SourceRootPath = @"[project.RootPath]\";
        }

        [Configure]
        public virtual void ConfigureAll(Project.Configuration conf, Target target)
        {
            conf.Name = @"[target.Optimization] [target.OutputType]";
            conf.ProjectFileName = "[project.Name]_[target.DevEnv]_[target.Platform]";
            conf.ProjectPath = @"[project.RootPath]\..\..\generated\";
            conf.TargetPath = @"[project.RootPath]\..\..\bin\[target.Platform]_[target.OutputType]_[target.Optimization]\";
            conf.Options.Add(Options.Vc.General.WindowsTargetPlatformVersion.Latest);
        }
    }

    [Generate]
    public class MnemosyneSdk : Solution
    {
        public MnemosyneSdk()
        {
            Name = "MnemosyneSdk";

            AddTargets(new Target(
                Platform.win64,
                DevEnv.vs2019,
                Optimization.Debug | Optimization.Release,
                OutputType.Dll
            ));
        }

        [Configure()]
        public void ConfigureAll(Configuration conf, Target target)
        {
            conf.Name = @"[target.Optimization]_[target.OutputType]";
            conf.SolutionFileName = "[solution.Name]_[target.DevEnv]_[target.Platform]";
            conf.SolutionPath = @"[solution.SharpmakeCsPath]\generated\";

            conf.AddProject<SdkUnitTests>(target);
            conf.AddProject<Sdk>(target);
        }

        [Main]
        public static void SharpmakeMain(Arguments arguments)
        {
            arguments.Generate<MnemosyneSdk>();
        }
    }
}