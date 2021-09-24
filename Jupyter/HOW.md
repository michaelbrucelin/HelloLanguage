# 启动JupyterLab

## 1. 安装

```bash
pip3 install jupyterlab
```

## 2. 启动

```bash
cd /root/GithubProjects/HelloLanguage/Jupyter
jupyter lab --allow-root --no-browser --port 8888 --ip=192.168.91.223
```

## 3. 查看jupyterlab支持的kernel

```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```

## 4. 同时支持Python2

由于上面安装的jupyterlab使用的python3安装的，所以jupyterlab默认使用的python3，下面使jupyterlab同时支持python2。

```bash
apt-get install python python-pip  # 安装python2
python2 -m pip install ipykernel   # 在python2中安装ipykernel包
# python2 -m ipykernel install --name python2  # 网上的说明文档中有这一步，但是实操过程中这一步失败了，而jupyterlab此时已经支持python2了
```

## 5. 再次确认

```bash
jupyter kernelspec list
Available kernels:
  python2            /usr/local/share/jupyter/kernels/python2
  python3            /usr/local/share/jupyter/kernels/python3
```

[jupyter其他语言支持: https://github.com/jupyter/jupyter/wiki/Jupyter-kernels](https://github.com/jupyter/jupyter/wiki/Jupyter-kernels)
