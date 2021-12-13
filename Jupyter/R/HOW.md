# 启动JupyterLab(R)

## 1. 安装依赖

- R Lang

```bash
apt-get install r-base r-base-dev
```

- jupyter notebook

## 2. 查看jupyterlab支持的kernel

```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```

## 3. 安装R kernel

```bash
R  # 进入R cli
```

```r
install.packages('IRkernel')
IRkernel::installspec()  # to register the kernel in the current R installation
q()
```

```bash
jupyter labextension install @techrah/text-shortcuts  # jupyter 插件
```

## 4. 再次确认

```bash
jupyter kernelspec list
Available kernels:
  ir                 /root/.local/share/jupyter/kernels/ir
  python3            /usr/local/share/jupyter/kernels/python3
```

[说明: https://github.com/IRkernel/IRkernel](https://github.com/IRkernel/IRkernel)
