# 启动JupyterLab(Emu86)

## 1. 安装依赖
- Python 3.6 or later
- Jupyter Notebook

## 2. 查看jupyterlab支持的kernel
```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```

## 3. 安装Emu86 Kernel
```bash
python3 -m pip install emu86
python3 -m kernels.intel.install
```

## 4. 再次确认
```bash
jupyter kernelspec list
Available kernels:
  intel              /root/.local/share/jupyter/kernels/intel
  python3            /usr/local/share/jupyter/kernels/python3
```

[说明: https://github.com/gcallah/Emu86/tree/master/kernels](https://github.com/gcallah/Emu86/tree/master/kernels)
