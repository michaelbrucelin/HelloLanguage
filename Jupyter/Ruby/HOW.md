# 启动JupyterLab(Ruby)

## 1. 安装依赖

- Ruby

```bash
apt-get install libtool libffi-dev ruby ruby-dev make
```

- jupyter notebook

## 2. 查看jupyterlab支持的kernel

```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```

## 3. 安装Ruby kernel

```bash
gem install iruby  # Debian10中使用gem install --user-install iruby无法进行下一步注册，不确认是为什么
iruby register --force
```

## 4. 再次确认

```bash
jupyter kernelspec list
Available kernels:
  python3            /usr/local/share/jupyter/kernels/python3
  ruby               /root/.local/share/jupyter/kernels/ruby
```

[说明: https://github.com/SciRuby/iruby](https://github.com/SciRuby/iruby)
