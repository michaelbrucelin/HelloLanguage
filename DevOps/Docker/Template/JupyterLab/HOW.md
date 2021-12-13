# JupyterLab in Dcoker

使用原生`python`，`python3-pip`安装的`jupyterlab`构建`JupyterLab`环境。

## TODO

- 配置密码：第一次登录页面中可以设置密码
- 常用配置：自动补全 \)
- 安装插件
- 配置`.net`, `C`, `go`等多语言环境
- 为每一种语言配置`hello world`示例文件

```bash
# 配置C++交互式语言环境时报错：
# 执行命令：./cpt.py --check-requirements && ./cpt.py --create-dev-env Debug --with-workdir=./cling-build/
# 报错信息：collect2: fatal error: ld terminated with signal 9 [killed]
# 据说是因为LLVM非常耗内存导致的（宿主机8G内存），下面使用添加虚拟内存的方式解决
# 使用下面的方式编译依然无效，没有继续解决这个问题
dd if=/dev/zero of=/tmp/swaptmp bs=1M count=32678  # 32GB，使用了一次16GB，仍然报错
mkswap /tmp/swaptmp
free
swapon /tmp/swaptmp
free
# swapoff /tmp/swaptmp
# rm -f /tmp/swaptmp

# 执行到配置C++环境时，可以监控一下内存的使用
while true; do free -h >> memroyrecord.txt; sleep 1s; done
tail -f memroyrecord.txt

docker build -t michaelbrucelin/jupyterlab .

# docker image save -o xxx
# docker image load

docker run -d -p 8888:8888 --name mylab michaelbrucelin/jupyterlab

docker logs mylab  # 查看登录的token
```
