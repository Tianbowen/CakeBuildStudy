using Cake.Core;
using Cake.Frosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeFrostingBuildConsole
{
    //public class BuildContextDemo : FrostingContext
    //{
    //    public bool Delay { get; set; }

    //    public BuildContextDemo(ICakeContext context) : base(context)
    //    {
    //        Delay = context.Arguments.HasArgument("delay");
    //    }
    //}

    //[TaskName("Hello")]
    //public sealed class HelloTask : FrostingTask<BuildContextDemo>
    //{
    //    public override void Run(BuildContextDemo context)
    //    {
    //        context.Log.Write(Cake.Core.Diagnostics.Verbosity.Normal, level: Cake.Core.Diagnostics.LogLevel.Information, "{0}", "Hello");
    //    }
    //}

    //[TaskName("World")]
    //[IsDependentOn(typeof(HelloTask))]
    //public sealed class WorldTask : AsyncFrostingTask<BuildContextDemo>
    //{
    //    public override bool ShouldRun(BuildContextDemo context)
    //    {
    //        return true;
    //    }

    //    public override async Task RunAsync(BuildContextDemo context)
    //    {
    //        if (context.Delay)
    //        {
    //            context.Log.Write(Cake.Core.Diagnostics.Verbosity.Normal, level: Cake.Core.Diagnostics.LogLevel.Information, "{0}", "Waiting");
    //            await Task.Delay(1500);
    //        }

    //        context.Log.Write(Cake.Core.Diagnostics.Verbosity.Normal, level: Cake.Core.Diagnostics.LogLevel.Information, "{0}", "World");
    //    }
    //}

    //[TaskName("Default")]
    //[IsDependentOn(typeof(WorldTask))]
    //public class DefaultTask : FrostingTask
    //{
    //}
}
