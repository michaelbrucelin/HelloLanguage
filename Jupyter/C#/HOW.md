# 启动JupyterLab(.net)

## 1. 安装依赖
- .net core sdk 5
- jupyter notebook
  
## 2. 查看jupyterlab支持的kernel
```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```

## 3. 安装.net kernel
https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json 是最新的发行版

```bash
dotnet tool install -g --add-source "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json" Microsoft.dotnet-interactive
dotnet interactive jupyter install
```

## 4. 再次确认
```bash
jupyter kernelspec list
Available kernels:
  .net-csharp        /root/.local/share/jupyter/kernels/.net-csharp
  .net-fsharp        /root/.local/share/jupyter/kernels/.net-fsharp
  .net-powershell    /root/.local/share/jupyter/kernels/.net-powershell
  python3            /usr/local/share/jupyter/kernels/python3
```

[说明: https://github.com/dotnet/interactive/blob/main/docs/NotebookswithJupyter.md](https://github.com/dotnet/interactive/blob/main/docs/NotebookswithJupyter.md)