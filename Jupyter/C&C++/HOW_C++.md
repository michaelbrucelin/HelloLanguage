# 启动JupyterLab(C++)

## 1. 安装依赖
- Python 3.6 or later
- Jupyter Notebook

## 2. 查看jupyterlab支持的kernel
```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```

## 3. 安装C++ Kernel
```bash
# 安装Cling
wget https://raw.githubusercontent.com/root-project/cling/master/tools/packaging/cpt.py
chmod +x cpt.py
./cpt.py --check-requirements && ./cpt.py --create-dev-env Debug --with-workdir=./cling-build/

# 安装Cling Kernel
```

## 4. 再次确认
```bash
jupyter kernelspec list
Available kernels:
  python3            /usr/local/share/jupyter/kernels/python3
```

[说明: https://github.com/root-project/cling](https://github.com/root-project/cling)  
[说明: https://github.com/root-project/cling/tree/master/tools/Jupyter](https://github.com/root-project/cling/tree/master/tools/Jupyter)
