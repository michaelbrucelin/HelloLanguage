# 启动JupyterLab(.net)

1. 安装.net core sdk 5
2. 安装jupyterlab
3. 查看jupyterlab支持的kernel
```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```
4. 添加.net kernel源
https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json 是最新的发行版
```bash
dotnet tool install -g --add-source "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json" Microsoft.dotnet-interactive
```
5. 安装.net kernel
```bash
dotnet interactive jupyter install
```
6. 再次确认
```bash
jupyter kernelspec list
Available kernels:
  .net-csharp        /root/.local/share/jupyter/kernels/.net-csharp
  .net-fsharp        /root/.local/share/jupyter/kernels/.net-fsharp
  .net-powershell    /root/.local/share/jupyter/kernels/.net-powershell
  python3            /usr/local/share/jupyter/kernels/python3
```
7. 启动
```bash
cd /root/GithubProjects/HelloLanguage/Jupyter
jupyter lab --allow-root --no-browser --port 8888 --ip=192.168.91.223
```

[说明](https://github.com/dotnet/interactive/blob/main/docs/NotebookswithJupyter.md)