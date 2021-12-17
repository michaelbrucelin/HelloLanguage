# 启动JupyterLab(JavaScript/NodeJS)

## 1. 安装依赖

- NodeJS

```bash
apt-get install nodejs npm
```

- jupyter notebook

## 2. 查看jupyterlab支持的kernel

```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```

## 3. 安装NodeJS kernel

```bash
npm install -g --unsafe-perm ijavascript
ijsinstall --install=global
```

## 4. 再次确认

```bash
jupyter kernelspec list
Available kernels:
  javascript         /usr/local/share/jupyter/kernels/javascript
  python3            /usr/local/share/jupyter/kernels/python3
```

[说明: https://github.com/n-riesco/ijavascript](https://github.com/n-riesco/ijavascript)
