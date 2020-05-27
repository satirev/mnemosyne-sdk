using Sharpmake;

namespace MnemosyneSdk
{
	[Generate]
	public class Sdk : Project
	{
		public Sdk()
		{
			Name = "Sdk";

			AddTargets(new Target(
					Platform.win64,
					DevEnv.vs2019,
					Optimization.Debug | Optimization.Release,
					OutputType.Dll
			));

			SourceRootPath = @"[project.SharpmakeCsPath]\";
		}

		[Configure()]
		public void ConfigureAll(Configuration conf, Target target)
		{
			conf.Name = @"[target.Optimization] [target.OutputType]";
			conf.ProjectFileName = "[project.Name]_[target.DevEnv]_[target.Platform]";
			conf.ProjectPath = @"[project.SharpmakeCsPath]\..\..\generated\";
			conf.TargetPath = @"[project.SharpmakeCsPath]\..\..\bin\[target.Platform]_[target.OutputType]_[target.Optimization]\";
			conf.Options.Add(Options.Vc.General.WindowsTargetPlatformVersion.Latest);
			
			conf.IncludePaths.Add(@"[project.SharpmakeCsPath]\include");
			conf.Defines.Add("MNEMOSYNE_SDK_API_EXPORT");
			
			if (target.OutputType == OutputType.Dll)
			{
				conf.Output = Configuration.OutputType.Dll;
			}
			else
			{
				conf.Output = Configuration.OutputType.Lib;
			}
		}
	}
}