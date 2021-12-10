# 启动JupyterLab(Bash)

## 1. 安装依赖

- Python 3.6 or later
- Jupyter Notebook

## 2. 查看jupyterlab支持的kernel

```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```

## 3. 安装bash Kernel

```bash
pip3 install bash_kernel
python3 -m bash_kernel.install
```

## 4. 再次确认

```bash
jupyter kernelspec list
Available kernels:
  bash               /usr/local/share/jupyter/kernels/bash
  python3            /usr/local/share/jupyter/kernels/python3
```

[说明: https://github.com/takluyver/bash_kernel](https://github.com/takluyver/bash_kernel)
