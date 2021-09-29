# 启动JupyterLab(C)

## 1. 安装依赖
- Python 3.6 or later
- Jupyter Notebook
- gcc

## 2. 查看jupyterlab支持的kernel
```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```

## 3. 安装C Kernel
```bash
pip3 install jupyter-c-kernel
install_c_kernel
```

## 4. 再次确认
```bash
jupyter kernelspec list
Available kernels:
  c                  /root/.local/share/jupyter/kernels/c
  python3            /usr/local/share/jupyter/kernels/python3
```

[说明: https://github.com/brendan-rius/jupyter-c-kernel](https://github.com/brendan-rius/jupyter-c-kernel)
