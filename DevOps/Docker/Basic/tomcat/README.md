# 构建一个Java应用服务

下面做一个更加“企业化”且用于传统工作负载的服务：获取`Tomcat`服务器上的`WAR`文件，并运行一个`Java`应用程序。  
为了做到这一点，构建一个有两个步骤的`Docker`管道。

- 一个镜像从`URL`拉取指定的`WAR`文件并将其保存到卷里。
- 一个含有`Tomcat`服务器的镜像运行这些下载的`WAR`文件。

## WAR文件的获取程序

构建一个镜像，这个镜像会下载WAR文件并将其挂载在卷里。

## 构建获取程序的镜像

```bash
cd fetcher
docker build -t mlin/fetcher .  # 构建获取程序的镜像
# Sending build context to Docker daemon  2.048kB
# Step 1/9 : FROM ubuntu:18.04
#  ---> 5a214d77f5d7
# ... ...
# Step 9/9 : CMD [ "--help" ]
#  ---> Running in d389fbf6b4e5
# Removing intermediate container d389fbf6b4e5
#  ---> 99a38a251ba8
# Successfully built 99a38a251ba8
# Successfully tagged mlin/fetcher:latest
```

## 获取WAR文件

创建一个容器，容器通过提供的`URL`下载了`sample.war`文件。文件保存保存在了容器的工作目录中。

```bash
docker run -it --name mlin_gwar mlin/fetcher \
    https://tomcat.apache.org/tomcat-8.0-doc/appdev/sample/sample.war
# --2021-11-26 00:38:25--  https://tomcat.apache.org/tomcat-8.0-doc/appdev/sample/sample.war
# Resolving tomcat.apache.org (tomcat.apache.org)... 151.101.2.132, 2a04:4e42::644
# Connecting to tomcat.apache.org (tomcat.apache.org)|151.101.2.132|:443... connected.
# HTTP request sent, awaiting response... 200 OK
# Length: 4606 (4.5K)
# Saving to: 'sample.war'
# sample.war        100%[================================================================>]   4.50K  --.-KB/s    in 0s
# 2021-11-26 00:38:26 (44.5 MB/s) - 'sample.war' saved [4606/4606]

docker inspect -f "{{ range .Mounts }}{{.}}{{end}}" mlin_gwar                                      # 查看示例里的卷
# {volume 7d3afac34506d3d0c3b368cf85c29641d3793673c09722a7f268eca8e66009cb /var/lib/docker/volumes/7d3afac34506d3d0c3b368cf85c29641d3793673c09722a7f268eca8e66009cb/_data /var/lib/tomcat8/webapps local  true }

ll /var/lib/docker/volumes/7d3afac34506d3d0c3b368cf85c29641d3793673c09722a7f268eca8e66009cb/_data  # 查看卷所在的目录
# total 8
# -rw-r--r-- 1 root root 4606 Aug  5  2013 sample.war
```

## 构建Tomcat 8镜像

```bash
cd ../tomcat8
docker build -t mlin/tomcat8 .
# Sending build context to Docker daemon  2.048kB
# Step 1/14 : FROM ubuntu:18.04
#  ---> 5a214d77f5d7
# ... ...
# Step 14/14 : ENTRYPOINT [ "/usr/share/tomcat8/bin/catalina.sh", "run" ]
#  ---> Running in 0b8fe3a54463
# Removing intermediate container 0b8fe3a54463
#  ---> 1ed17f7751d0
# Successfully built 1ed17f7751d0
# Successfully tagged mlin/tomcat8:latest
```

## 运行WAR文件

创建一个新的`Tomcat`实例，运行示例应用，在浏览器中打开[http://ip:port/sample/](http://ip:port/sample/)来测试。

```bash
docker run --name mlin_tomcat8 --volumes-from mlin_gwar -d -P mlin/tomcat8
# e95ff50bfd1ed779907f8cb3aa8bc8f3504541f86225c84546c8d1b88e8eb4fe

docker port mlin_tomcat8
# 8080/tcp -> 0.0.0.0:49164
```

## 基于Tomcat应用服务器的构建服务

现在有了自服务Web服务的基础模块，下面基于这些基础模块做扩展。  
为了做到这一点，已经构建好了一个简单的基于`Sinatra`的`Web`应用（`TProv`），这个应用可以通过网页自动展示`Tomcat`应用。

在浏览器中打开[http://ip:4567](http://ip:4567)可以打开`TProv`应用，然后可以下载`war`包，放入卷中，供`Tomcat`服务使用。

```bash
# 可以把TProv应用安装在Docker容器里，这里直接安装在宿主机上
# yum install -y make ruby             # CentOS7
apt-get -y install make ruby ruby-dev  # Debian10

gem install --no-rdoc --no-ri tprov    # 安装TProv应用

tprov                                  # 启动TProv应用
```
