using Sharpmake;

[module: Include("../sdk/sdk.sharpmake.cs")]

namespace MnemosyneSdk
{
	[Generate]
	public class SdkUnitTests : Project
	{
		public SdkUnitTests()
		{
			Name = "SdkUnitTests";
			
			AddTargets(new Target(
					Platform.win64,
					DevEnv.vs2019,
					Optimization.Debug | Optimization.Release,
					OutputType.Dll
			));

			SourceRootPath = @"[project.SharpmakeCsPath]\src\";
		}
		
		[Configure()]
		public void ConfigureAll(Configuration conf, Target target)
		{
			conf.Name = @"[target.Optimization] [target.OutputType]";
			conf.ProjectFileName = "[project.Name]_[target.DevEnv]_[target.Platform]";
			conf.ProjectPath = @"[project.SharpmakeCsPath]\..\..\generated\";
			conf.TargetPath = @"[project.SharpmakeCsPath]\..\..\bin\[target.Optimization]\";
			conf.Options.Add(Options.Vc.General.WindowsTargetPlatformVersion.Latest);
			
			conf.AddPrivateDependency<Sdk>(target);
			
			conf.IncludePaths.Add(@"[project.SharpmakeCsPath]\..\..\vendor\googletest\googletest");
			conf.IncludePaths.Add(@"[project.SharpmakeCsPath]\..\..\vendor\googletest\googletest\Include");
			conf.IncludePaths.Add(@"[project.SharpmakeCsPath]\..\..\vendor\googletest\googlemock");
			conf.IncludePaths.Add(@"[project.SharpmakeCsPath]\..\..\vendor\googletest\googlemock\Include");
		}
	}
}