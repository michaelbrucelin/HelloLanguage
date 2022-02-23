# 创建.netcore console项目

## 创建项目

```bash
dotnet new console -o HelloConsole
# Welcome to .NET 6.0!
# ---------------------
# SDK Version: 6.0.200
# 
# Telemetry
# ---------
# The .NET tools collect usage data in order to help us improve your experience. It is collected by Microsoft and shared with the community. You can opt-out of telemetry by setting the DOTNET_CLI_TELEMETRY_OPTOUT environment variable to '1' or 'true' using your favorite shell.
# 
# Read more about .NET CLI Tools telemetry: https://aka.ms/dotnet-cli-telemetry
# 
# ----------------
# Installed an ASP.NET Core HTTPS development certificate.
# To trust the certificate run 'dotnet dev-certs https --trust' (Windows and macOS only).
# Learn about HTTPS: https://aka.ms/dotnet-https
# ----------------
# Write your first app: https://aka.ms/dotnet-hello-world
# Find out what's new: https://aka.ms/dotnet-whats-new
# Explore documentation: https://aka.ms/dotnet-docs
# Report issues and find source on GitHub: https://github.com/dotnet/core
# Use 'dotnet --help' to see available commands or visit: https://aka.ms/dotnet-cli
# --------------------------------------------------------------------------------------
# The template "Console App" was created successfully.
# 
# Processing post-creation actions...
# Running 'dotnet restore' on /root/GithubProjects/HelloLanguage/Language/C#/PlayGround/HelloConsole/HelloConsole.csproj...
#   Determining projects to restore...
#   Restored /root/GithubProjects/HelloLanguage/Language/C#/PlayGround/HelloConsole/HelloConsole.csproj (in 169 ms).
# Restore succeeded.
```

## 查看创建的项目模板

```bash
tree HelloConsole/
# HelloConsole/
# ├── HelloConsole.csproj
# ├── obj
# │   ├── HelloConsole.csproj.nuget.dgspec.json
# │   ├── HelloConsole.csproj.nuget.g.props
# │   ├── HelloConsole.csproj.nuget.g.targets
# │   ├── project.assets.json
# │   └── project.nuget.cache
# └── Program.cs
# 
# 1 directory, 7 files
```

## 运行项目

```bash
cd HelloConsole/
dotnet build  # 编译
# Microsoft (R) Build Engine version 17.1.0+ae57d105c for .NET
# Copyright (C) Microsoft Corporation. All rights reserved.
# 
#   Determining projects to restore...
#   All projects are up-to-date for restore.
#   HelloConsole -> /root/GithubProjects/HelloLanguage/Language/C#/PlayGround/HelloConsole/bin/Debug/net6.0/HelloConsole.dll
# 
# Build succeeded.
#     0 Warning(s)
#     0 Error(s)
# 
# Time Elapsed 00:00:01.88
dotnet run    # 运行
# Hello, World!
```
