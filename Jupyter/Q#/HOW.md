# 启动JupyterLab(Q#)

## 1. 安装依赖
- Python 3.6 or later
- Jupyter Notebook
- .NET Core SDK 3.1

## 2. 查看jupyterlab支持的kernel
```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```

## 3. 安装Q# Kernel
```bash
dotnet tool install -g Microsoft.Quantum.IQSharp
dotnet iqsharp install
```

## 4. 再次确认
```bash
jupyter kernelspec list
Available kernels:
  iqsharp            /usr/local/share/jupyter/kernels/iqsharp
  python3            /usr/local/share/jupyter/kernels/python3
```

[说明: https://github.com/microsoft/iqsharp](https://github.com/microsoft/iqsharp)
[说明: https://docs.microsoft.com/en-us/azure/quantum/install-jupyter-qdk?tabs=tabid-dotnetcli](https://docs.microsoft.com/en-us/azure/quantum/install-jupyter-qdk?tabs=tabid-dotnetcli)
