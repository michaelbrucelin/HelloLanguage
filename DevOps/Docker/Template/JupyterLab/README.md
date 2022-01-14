# JupyterLab in Dcoker

使用原生`python`，`python3-pip`安装的`jupyterlab`构建`JupyterLab`环境。

## TODO

- 为每一种语言配置`hello world`示例文件
- 使用`jupyter lab --app-dir`，WORKDIR仍然在`/root/`下

## 制作Docker镜像

### 为宿主机添加一个大的虚拟内存

如果主机内存较小，添加一个大的虚拟内存，可以避免编译过程因为内存不足导致错误。

```bash
dd if=/dev/zero of=/tmp/swaptmp bs=1M count=32678
mkswap /tmp/swaptmp
free
swapon /tmp/swaptmp
free
# swapoff /tmp/swaptmp
# rm -f /tmp/swaptmp
```

### 制作镜像并运行容器

```bash
wget https://raw.githubusercontent.com/michaelbrucelin/HelloLanguage/main/DevOps/Docker/Template/JupyterLab/Dockerfile
docker build -t michaelbrucelin/jupyterlab .

# 备份到dockerhub
docker login
docker push michaelbrucelin/jupyterlab
docker logout

# 备份到网盘
# 使用http服务供网盘离线下载（python内建的http server失败了几次，不确认是因为文件太大不稳定还是什么其他原因，最后用的nginx解决的）
docker save -o /root/jupyterlab.docker.tar michaelbrucelin/jupyterlab
docker load < /root/jupyterlab.docker.tar

docker run -d -p 8888:8888 --name mylab -v /PATH/TO/CODE:/home/playground michaelbrucelin/jupyterlab
docker logs mylab  # 查看登录的token
```

## 常用配置

### 配置系统

```bash
docker exec -ti mylab /bin/bash

alias ls='ls --color=auto'
alias ll='ls -l --color=auto'
```

### 安装常用的Python包

```bash
docker exec -ti mylab /bin/bash
cd

python3 -m pip install numpy scipy sympy scikit-learn pandas matplotlib seaborn
python3 -m pip install pillow
```

### 配置Jupyter

- 第一次登录在浏览器页面中设置登录密码
- 关闭左下角的Simple选项
- 自动补全：`Settings`——>`Auto Close Brackets`
- 左侧目录树，关闭`Last Modified`列

### 安装Jupyter插件

```bash
docker exec -ti mylab /bin/bash
cd

# set Jupyter plugins(Depend on some environment, such as nodejs)
jupyter labextension enable
python3 -m pip install ipympl
jupyter labextension install @jupyter-widgets/jupyterlab-manager jupyter-matplotlib
python3 -m pip install nbresuse
jupyter labextension install jupyterlab-topbar-extension jupyterlab-system-monitor
python3 -m pip install jupyter-kite
jupyter labextension install @kiteco/jupyterlab-kite
python3 -m pip install jupyterlab-snippets
jupyter labextension install jupyterlab-snippets
jupyter labextension install @jupyterlab/debugger @jupyterlab/debugger-extension @jupyterlab/latex @jupyterlab/katex-extension @jupyterlab/toc-extension @jupyterlab/geojson-extension
jupyter labextension install @lckr/jupyterlab_variableinspector jupyterlab-drawio jupyterlab-execute-time jupyterlab-spreadsheet

jupyter --version
# Selected Jupyter core packages...
# IPython          : 7.31.0
# ipykernel        : 6.6.1
# ipywidgets       : 7.6.5
# jupyter_client   : 7.1.0
# jupyter_core     : 4.9.1
# jupyter_server   : 1.13.2
# jupyterlab       : 3.2.7
# nbclient         : 0.5.9
# nbconvert        : 6.4.0
# nbformat         : 5.1.3
# notebook         : 6.4.7
# qtconsole        : 5.2.2
# traitlets        : 5.1.1
```
