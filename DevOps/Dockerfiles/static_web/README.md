# 使用Docker测试静态网站

将Docker作为本地Web开发环境是Docker的一个最简单的应用场景。这样的环境可以完全复制生产环境，并确保用户开发的东西在生产环境中也能运行。下面从将Nginx Web服务器安装到容器来架构一个简单的网站开始。这个网站暂且命名为Sample。

## 构建新的Nginx镜像

```bash
docker build -t mlin/nginx .
# Sending build context to Docker daemon  5.632kB
# Step 1/8 : FROM ubuntu:18.04
#  ---> 5a214d77f5d7
# Step 2/8 : LABEL maintainer="mlin@mlin.com"
#  ---> Running in 0ced90f7a284
# Removing intermediate container 0ced90f7a284
#  ---> d40adc752a07
# Step 3/8 : ENV REFRESHED_AT 2014-06-01
#  ---> Running in 4945acd789a7
# Removing intermediate container 4945acd789a7
#  ---> e41e17ad2ac0
# Step 4/8 : RUN apt-get -qq update && apt-get -qq install nginx
#  ---> Running in db3e5ee036cf
# ... ...
# Removing intermediate container db3e5ee036cf
#  ---> 6385918c8f2a
# Step 5/8 : RUN mkdir -p /var/www/html/website
#  ---> Running in 0c41a08e836a
# Removing intermediate container 0c41a08e836a
#  ---> ef5623f59b4a
# Step 6/8 : ADD nginx/global.conf /etc/nginx/conf.d/
#  ---> dc876562c952
# Step 7/8 : ADD nginx/nginx.conf /etc/nginx/nginx.conf
#  ---> 54ba8e6a6c1a
# Step 8/8 : EXPOSE 80
#  ---> Running in 1418f4f22b7b
# Removing intermediate container 1418f4f22b7b
#  ---> 6e2a7e56d9d8
# Successfully built 6e2a7e56d9d8
# Successfully tagged mlin/nginx:latest
```

## 展示Nginx镜像的构建历史

```bash
docker history mlin/nginx
# IMAGE          CREATED         CREATED BY                                      SIZE      COMMENT
# 6e2a7e56d9d8   2 minutes ago   /bin/sh -c #(nop)  EXPOSE 80                    0B
# 54ba8e6a6c1a   2 minutes ago   /bin/sh -c #(nop) ADD file:e0f4b0e393bb2007e…   972B
# dc876562c952   2 minutes ago   /bin/sh -c #(nop) ADD file:275d92bddef798186…   396B
# ef5623f59b4a   2 minutes ago   /bin/sh -c mkdir -p /var/www/html/website       0B
# 6385918c8f2a   2 minutes ago   /bin/sh -c apt-get -qq update && apt-get -qq…   98.6MB
# e41e17ad2ac0   3 minutes ago   /bin/sh -c #(nop)  ENV REFRESHED_AT=2014-06-…   0B
# d40adc752a07   3 minutes ago   /bin/sh -c #(nop)  LABEL maintainer=mlin@mli…   0B
# 5a214d77f5d7   5 weeks ago     /bin/sh -c #(nop)  CMD ["bash"]                 0B
# <missing>      5 weeks ago     /bin/sh -c #(nop) ADD file:0d82cd095966e8ee7…   63.1MB
```

## 构建第一个Nginx测试容器

使用`docker run`命令从mlin/nginx镜像创建了一个名为website的容器。

在执行`docker run`时传入了`nginx`作为容器的启动命令。一般情况下，这个命令无法让Nginx以交互的方式运行。  
我们已经在提供给Docker的配置里加入了指令`daemon off`，这个指令让Nginx启动后以交互的方式在前台运行。

```bash
docker run -d -p 8080:80 --name website -v $PWD/website:/var/www/html/website mlin/nginx nginx
# cb181ae28d69a78a4ebf02770372ccbb9202d02fc4016cb3f3b8bc31f7cfe67b

# 控制卷的写状态
# 这将使目的目录/var/www/html/website变成只读状态
docker run -d -p 8080:80 --name website -v $PWD/website:/var/www/html/website:ro mlin/nginx nginx
```
