# CakeBuildStudy
A sample tutorial for learning Cake automated build tools

1. Use **Cake.Tool** to compile the project.

```bash
# search cake 
dotnet tool search cake
# new tool-manifest
dotnet tool new-manifest
# install cake.tool
dotnet tool install Cake.Tool --version 3.0.0
# cd build.cake folder // Navigate to the folder containing the build.cake file.
cd ..
# dotnet cake
error: Run "dotnet tool restore" to make the "dotnet-cake" command available.
# or dotnet tool restore
input: dotnet tool restore
output: Tool 'cake.tool' (version '0.38.5') was restored. Available commands: dotnet-cake
Restore was successful.
# dotnet cake
dotnet cake
Build ...

```

Content of build.cake file:

```txt
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
```



2. Use **Cake.Frosting** to compile the project.

```bash
# 方式一
# 新增Frosting模板
dotnet new --install Cake.Frosting.Template
# 创建Frosting项目
dotnet new cakefrosting


# 方式二 
# 引用Nuget包 Cake.Frosting
dotnet package add Cake.Frosting
```

注意: 

**.NET Framework** 项目编译使用**DotNetBuild**  **DotNetTest**

**.Net Core**使用 **DotNetCoreBuild** **DotNetCoreTest**

例子:

```c#
public class BuildContext:FrostingContext
{
    public string MsBuildConfiguration { get; set; }

    public BuildContext(ICakeContext context) : base(context)
    {
        MsBuildConfiguration = context.Argument("configuration", "Release");
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
```

3. 配置
   - 环境变量
   - 配置文件 cake.config
   - 命令行

```txt
; The configuration file for Cake.

[Nuget]
Source=https://mycustomurl
# 配置文件 支持环境变量替换 例如: NUGET_REPOSITORY
Source=https://%NUGET_REPOSITORY%/api/v2
```

4. 任务依赖

```csharp
-- 正向依赖
[TaskName("B")]
[IsDependentOn(typeof(TaskA))]    
-- 反向依赖
[TaskName("A")]
[IsDependeeOf(typeof(TaskB))]
-- 多重依赖
[TaskName("C")]
[IsDependentOn(typeof(TaskA))]
[IsDependentOn(typeof(TaskB))]
```

5. 声明周期

```csharp
-- 声明 全局生命周期
new CakeHost().UseLifetime<BuildLifetime>();

public class BuildLifetime : FrostingLifetime<BuildContext>{
    public override void Setup(BuildContext context, ISetupContext info){
        // Executed BEFORE the first task.
    }
    public override void Teardown(BuildContext context, ITeardownContext info){
        // Executed AFTER the last task.
    }
}
-- 声明 任务声明周期
new CakeHost().UseTaskLifetime<TaskLifetime>();

public class TaskLifetime : FrostingTaskLifetime<BuildContext>{
    public override void Setup(BuildContext context, ITaskSetupContext info)
    {
         // Executed BEFORE every task.
    }
    public override void Teardown(BuildContext context, ITaskTeardownContext info)
    {
        // Executed AFTER every task.
    }
}
```

6. 目标任务

默认:Default ,也可用参数指定 

```bash
# exclusive 仅运行指定目标而没有依赖项
--target=Publish --exclusive 
```

