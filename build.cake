var target=Argument("target","Build");
var configuration=Argument("configuration","Release");

Task("Build")
    .Does(() =>
{
    DotNetCoreBuild("CakeBuildStudy.sln", new DotNetCoreBuildSettings
    {
        Configuration = configuration,
    });
});

RunTarget(target);