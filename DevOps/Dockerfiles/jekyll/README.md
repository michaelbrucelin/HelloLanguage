# 构建Jekyll服务

这里使用`Jekyll`框架的自定义网站。我们会构建以下两个镜像。

- 一个镜像安装了`Jekyll`及其他用于构建`Jekyll`网站的必要的软件包。
- 一个镜像通过`Apache`来让`Jekyll`网站工作起来。

我们打算在启动容器时，通过创建一个新的`Jekyll`网站来实现自服务。工作流程如下：

- 创建`Jekyll`基础镜像和`Apache`镜像（只需要构建一次）。
- 从`Jekyll`镜像创建一个容器，这个容器存放通过卷挂载的网站源代码。
- 从`Apache`镜像创建一个容器，这个容器利用包含编译后的网站的卷，并为其服务。
- 在网站需要更新时，清理并重复上面的步骤。

可以把这个例子看作是创建一个多主机站点最简单的方法。

## 构建Jekyll基础镜像

```bash
cd jekyll
docker build -t mlin/jekyll .
# Sending build context to Docker daemon   2.56kB
# Step 1/10 : FROM ubuntu:18.04
#  ---> 5a214d77f5d7
# ... ...
# Step 10/10 : ENTRYPOINT [ "jekyll", "build", "--destination=/var/www/html" ]
#  ---> Running in 4dcb9fe33560
# Removing intermediate container 4dcb9fe33560
#  ---> e203ecba07db
# Successfully built e203ecba07db
# Successfully tagged mlin/jekyll:latest

docker images
# REPOSITORY           TAG       IMAGE ID       CREATED         SIZE
# mlin/jekyll          latest    e203ecba07db   2 minutes ago   438MB
```

## 构建Apache镜像

```bash
cd ../apache
docker build -t mlin/apache .
# Sending build context to Docker daemon   2.56kB
# Step 1/16 : FROM ubuntu:18.04
#  ---> 5a214d77f5d7
# ... ...
# Step 16/16 : CMD ["-D", "FOREGROUND"]
#  ---> Running in d55edf542403
# Removing intermediate container d55edf542403
#  ---> 891a5635ab91
# Successfully built 891a5635ab91
# Successfully tagged mlin/apache:latest

docker images
# REPOSITORY           TAG       IMAGE ID       CREATED          SIZE
# mlin/apache          latest    891a5635ab91   39 seconds ago   198MB
```

## 启动Jekyll网站

现在有了以下两个镜像。

- `Jekyll`：安装了`Ruby`及其他必备软件包的`Jekyll`镜像。
- `Apache`：通过`Apache Web`服务器来让`Jekyll`网站工作起来的镜像。

使用`docker run`命令来创建一个新的`Jekyll`容器开始网站。  
这里启动了一个叫作`mlin_blog`的新容器，把本地的`/PATH/TO/mlin_blog`目录作为`/data/`卷挂载到容器里。  
容器已经拿到网站的源代码，并将其构建到已编译的网站，存放到`/var/www/html/`目录。

## 创建Jekyll容器

```bash
cd ..
docker run -v /PATH/TO/mlin_blog:/data/ --name mlin_blog mlin/jekyll
# Configuration file: /data/_config.yml
#             Source: /data
#        Destination: /var/www/html
#       Generating... 
#                     done.
#  Auto-regeneration: disabled. Use --watch to enable.

docker ps -l
# CONTAINER ID   IMAGE         COMMAND                  CREATED          STATUS                      PORTS     NAMES
# a29ab3debc7f   mlin/jekyll   "jekyll build --dest…"   55 seconds ago   Exited (0) 52 seconds ago             mlin_blog
```

## 创建Apache容器

完成后可以在浏览器中浏览网站。

```bash
# --volumes-from标志把指定容器里的所有卷都加入新创建的容器里。
# 这意味着，Apache容器可以访问上面创建的mlin_blog容器里/var/www/html卷中存放的编译后的Jekyll网站。
# 即便mlin_blog容器没有运行，Apache容器也可以访问这个卷。
docker run -d -P --volumes-from mlin_blog --name mlin_apache mlin/apache
# e09526e41d682e02ccb2dce57299873058a522735d5c0d53c9b0726f5e0c6c8a

docker port mlin_apache
# 80/tcp -> 0.0.0.0:49163
```
