# 启动JupyterLab(C++)

编译Cling，编译不过去，fatal error: ld terminated with signal 9 [Killed]，网上有说是内存不够用（>=8GB）导致的，后来没继续尝试。

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
cd /usr/local
wget https://raw.githubusercontent.com/root-project/cling/master/tools/packaging/cpt.py
chmod +x cpt.py
./cpt.py --check-requirements && ./cpt.py --create-dev-env Debug --with-workdir=./cling-build/

# 安装Cling Kernel
export PATH=/usr/local/cling-build/builddir/bin:$PATH
cd /usr/local/cling-build/cling-src/tools/cling/tools/Jupyter/kernel
python3 -m pip install -e .

# register the kernelspec for C++17/C++1z/C++14/C++11:
# the user can install whichever kernel(s) they
# wish:
jupyter-kernelspec install cling-cpp17
jupyter-kernelspec install cling-cpp1z
jupyter-kernelspec install cling-cpp14
jupyter-kernelspec install cling-cpp11
```

## 4. 再次确认

```bash
jupyter kernelspec list
Available kernels:
  python3            /usr/local/share/jupyter/kernels/python3
```

[说明: https://github.com/root-project/cling](https://github.com/root-project/cling)  
[说明: https://github.com/root-project/cling/tree/master/tools/Jupyter](https://github.com/root-project/cling/tree/master/tools/Jupyter)
