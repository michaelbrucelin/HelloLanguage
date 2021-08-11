# 启动JupyterLab(Julia)

## 1. 安装依赖
- Julia

```bash
wget https://julialang-s3.julialang.org/bin/linux/x64/1.6/julia-1.6.2-linux-x86_64.tar.gz
rm -rf /usr/local/julia && tar -C /usr/local -xzf julia-1.6.2-linux-x86_64.tar.gz
mv /usr/local/julia-1.6.2/ /usr/local/julia/
export PATH=$PATH:/usr/local/julia/bin
julia version
```

- jupyter notebook
  
## 2. 查看jupyterlab支持的kernel
```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```

## 3. 安装Julia kernel

```bash
julia
> ]
> add IJulia
```

## 4. 再次确认
```bash
jupyter kernelspec list
Available kernels:
  julia-1.6          /root/.local/share/jupyter/kernels/julia-1.6
  python3            /usr/local/share/jupyter/kernels/python3
```

[说明: https://julialang.org/downloads/platform/#linux_and_freebsd](https://julialang.org/downloads/platform/#linux_and_freebsd)
[说明: https://github.com/JuliaLang/IJulia.jl](https://github.com/JuliaLang/IJulia.jl)
