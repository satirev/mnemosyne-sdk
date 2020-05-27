// Copyright (c) 2020 Mnemosyne

using Sharpmake;

[module: Include("../sdk/sdk.sharpmake.cs")]

namespace MnemosyneSdk
{
	[Generate]
	public class SdkUnitTests : BaseProject
	{
		public SdkUnitTests()
		{
			Name = "SdkUnitTests";
		}

		public override void ConfigureAll(Configuration conf, Target target)
		{
			base.ConfigureAll(conf, target);

			conf.AddPrivateDependency<Sdk>(target);
			conf.IncludePaths.Add(@"[project.SharpmakeCsPath]\..\..\vendor\googletest\googletest");
			conf.IncludePaths.Add(@"[project.SharpmakeCsPath]\..\..\vendor\googletest\googletest\Include");
			conf.IncludePaths.Add(@"[project.SharpmakeCsPath]\..\..\vendor\googletest\googlemock");
			conf.IncludePaths.Add(@"[project.SharpmakeCsPath]\..\..\vendor\googletest\googlemock\Include");
		}
	}
}