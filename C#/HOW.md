# 创建.netcore console项目

```bash
dotnet new console -o csharp_helloWorld
```

# 查看创建的项目模板

```bash
tree csharp_helloWorld/
csharp_helloWorld/
├── csharp_helloWorld.csproj
├── obj
│   ├── csharp_helloWorld.csproj.nuget.dgspec.json
│   ├── csharp_helloWorld.csproj.nuget.g.props
│   ├── csharp_helloWorld.csproj.nuget.g.targets
│   ├── project.assets.json
│   └── project.nuget.cache
└── Program.cs
1 directory, 7 files
```

# 运行项目

```bash
cd csharp_helloWorld/
dotnet build  # 编译
dotnet run    # 运行
Hello World!
```
