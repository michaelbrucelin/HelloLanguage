# 启动JupyterLab(Go)

## 1. 安装依赖

- Python 3.6 or later
- Jupyter Notebook
- Go 1.13+
- git

## 2. 查看jupyterlab支持的kernel

```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```

## 3. 安装Go Kernel

```bash
go env -w GOPROXY=https://goproxy.cn,direct  # 文档是没有这一步的，但是国内无法访问，这一步是设置代理
env GO111MODULE=on go get github.com/gopherdata/gophernotes
mkdir -p ~/.local/share/jupyter/kernels/gophernotes
cd ~/.local/share/jupyter/kernels/gophernotes
cp "$(go env GOPATH)"/pkg/mod/github.com/gopherdata/gophernotes@v0.7.3/kernel/*  "."
chmod +w ./kernel.json # in case copied kernel.json has no write permission
sed "s|gophernotes|$(go env GOPATH)/bin/gophernotes|" < kernel.json.in > kernel.json
```

## 4. 再次确认

```bash
jupyter kernelspec list
Available kernels:
  gophernotes        /root/.local/share/jupyter/kernels/gophernotes
  python3            /usr/local/share/jupyter/kernels/python3
```

[说明: https://github.com/gopherdata/gophernotes#linux-or-freebsd](https://github.com/gopherdata/gophernotes#linux-or-freebsd)
