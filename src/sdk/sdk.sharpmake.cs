// Copyright (c) 2020 Mnemosyne

using Sharpmake;

namespace MnemosyneSdk
{
	[Generate]
	public class Sdk : BaseProject
	{
		public Sdk()
		{
			Name = "Sdk";
		}

		public override void ConfigureAll(Configuration conf, Target target)
		{
			base.ConfigureAll(conf, target);

			conf.IncludePaths.Add(@"[project.SharpmakeCsPath]\include");
			conf.Defines.Add("MNEMOSYNE_SDK_API_EXPORT");
			conf.Output = Configuration.OutputType.Dll;
		}
	}
}