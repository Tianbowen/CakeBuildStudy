using Cake.Common;
using Cake.Common.IO;
using Cake.Core;
using Cake.Frosting;
using Cake.Common.Tools.DotNetCore;
using Cake.Common.Diagnostics;
using Cake.Common.Tools.DotNetCore.Test;

namespace CakeFrostingBuildConsole
{
    public class BuildContext : FrostingContext
    {
        public string MsBuildConfiguration { get; set; }

        public BuildContext(ICakeContext context) : base(context)
        {
            MsBuildConfiguration = context.Argument("configuration", "Release");
            context.Information("MsBuildConfiguration:" + MsBuildConfiguration);
        }
    }


    [TaskName("Clean")]
    public sealed class CleanTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            // 清理目录
            context.CleanDirectory($"../CleanFolder/{context.MsBuildConfiguration}");
        }
    }

    [TaskName("Build")]
    [IsDependentOn(typeof(CleanTask))]
    public sealed class BuildTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.Information("自定义日志");
            context.DotNetCoreBuild("../CakeBuildStudy.sln", new Cake.Common.Tools.DotNetCore.Build.DotNetCoreBuildSettings
            {
                Configuration = context.MsBuildConfiguration,
            });
        }
    }

    [TaskName("Test")]
    [IsDependentOn(typeof(BuildTask))]
    public sealed class TestTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.DotNetCoreTest("", new DotNetCoreTestSettings
            {
                Configuration = context.MsBuildConfiguration,
                NoBuild = true
            });
        }
    }

    [IsDependentOn(typeof(TestTask))]
    public sealed class Default : FrostingTask
    {
    }
}
