using Cake.Frosting;
using System;

namespace CakeFrostingBuildConsole
{
    class Program
    {
        static int Main(string[] args)
        {
            return new CakeHost()
                .UseContext<BuildContext>()
                .Run(args);
        }
    }
}
