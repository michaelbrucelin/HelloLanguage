# 使用Docker构建并测试Web应用程序

这个示例测试一个Web应用程序。这里测试一个基于`Sinatra`的`Web`应用程序，而不是静态网站，然后我们将基于`Docker`来对这个应用进行测试。  
`Sinatra`是一个基于`Ruby`的`Web`应用框架，它包含一个Web应用库，以及简单的领域专用语言（即`DSL`）来构建`Web`应用程序。  
与其他复杂的`Web`应用框架（如`Ruby on Rails`）不同，`Sinatra`并不遵循`MVC`模式，而关注于让开发者创建快速、简单的`Web`应用。  
因此，`Sinatra`非常适合用来创建一个小型的示例应用进行测试。

这里我们将创建一个应用程序，它接收输入的`URL`参数，并以`JSON`散列的结构输出到客户端。这里也将展示一下如何将`Docker`容器链接起来。

## 构建新的Sinatra镜像

```bash
docker build -t mlin/sinatra .
# Sending build context to Docker daemon   16.9kB
# Step 1/8 : FROM ubuntu:18.04
# 18.04: Pulling from library/ubuntu
# 284055322776: Pull complete 
# Digest: sha256:0fedbd5bd9fb72089c7bbca476949e10593cebed9b1fb9edf5b79dbbacddd7d6
# Status: Downloaded newer image for ubuntu:18.04
#  ---> 5a214d77f5d7
# Step 2/8 : LABEL maintainer="mlin@mlin.com"
#  ---> Running in 16204c751252
# Removing intermediate container 16204c751252
#  ---> e45487a19fa1
# Step 3/8 : ENV REFRESHED_AT 2014-06-01
#  ---> Running in 102244dbf290
# Removing intermediate container 102244dbf290
#  ---> c9bd1b2c4708
# Step 4/8 : RUN apt-get -yqq update && apt-get -yqq install ruby ruby-dev build-essential redis-tools
#  ---> Running in 219ef8404f24
# ... ...
# Removing intermediate container 219ef8404f24
#  ---> c1a3ce649ef3
# Step 5/8 : RUN gem install --no-rdoc --no-ri sinatra json redis
#  ---> Running in 155d491886aa
# Successfully installed rack-2.2.3
# ... ...
# Successfully installed redis-4.5.1
# 8 gems installed
# Removing intermediate container 155d491886aa
#  ---> 0eb8caaa076e
# Step 6/8 : RUN mkdir -p /opt/webapp
#  ---> Running in c390e6e00350
# Removing intermediate container c390e6e00350
#  ---> ce4d5063cede
# Step 7/8 : EXPOSE 4567
#  ---> Running in bdbc6200eec2
# Removing intermediate container bdbc6200eec2
#  ---> f029fc26d2c3
# Step 8/8 : CMD [ "/opt/webapp/bin/webapp" ]
#  ---> Running in 4f444cebadf5
# Removing intermediate container 4f444cebadf5
#  ---> e392bad1e5aa
# Successfully built e392bad1e5aa
# Successfully tagged mlin/sinatra:latest
```

## 启动第一个Sinatra容器

现在开始测试第一个容器，使用webapp目录

```bash
chmod +x webapp/bin/webapp  # 保证webapp/bin/webapp 这个文件可以执行
docker run -d -p 4567 --name webapp -v $PWD/webapp:/opt/webapp mlin/sinatra
# 729fa1b3d04b058c8f4e1775e11f373bd1aeea28605cdb9e7e4b595e0cf4d610
```

## 检查Sinatra容器

```bash
docker logs webapp       # 检查Sinatra容器的日志
# [2021-11-18 00:00:17] INFO  WEBrick 1.4.2
# [2021-11-18 00:00:17] INFO  ruby 2.5.1 (2018-03-29) [x86_64-linux-gnu]
# == Sinatra (v2.1.0) has taken the stage on 4567 for development with backup from WEBrick
# [2021-11-18 00:00:17] INFO  WEBrick::HTTPServer#start: pid=1 port=4567

docker logs -f webapp    # 持续跟踪Sinatra容器的日志

docker top webapp        # 列出Sinatra进程
# UID     PID     PPID    C    STIME    TTY    TIME        CMD
# root    5082    5062    0    00:32    ?      00:00:00    /usr/bin/ruby /opt/webapp/bin/webapp

docker port webapp 4567  # 检查Sinatra的端口映射
# 0.0.0.0:49155
```

## 测试Sinatra应用程序

```bash
curl -i -H 'Accept: application/json' -d 'name=Foo&status=Bar' http://localhost:49155/json
# HTTP/1.1 200 OK 
# Content-Type: text/html;charset=utf-8
# Content-Length: 29
# X-Xss-Protection: 1; mode=block
# X-Content-Type-Options: nosniff
# X-Frame-Options: SAMEORIGIN
# Server: WEBrick/1.4.2 (Ruby/2.5.1/2018-03-29)
# Date: Thu, 18 Nov 2021 00:05:12 GMT
# Connection: Keep-Alive
# 
# {"name":"Foo","status":"Bar"}
```

## 扩展Sinatra应用程序来使用Redis

现在我们将要扩展`Sinatra`应用程序，加入`Redis`后端数据库，并在`Redis`数据库中存储输入的`URL`参数。  
为了达到这个目的，我们要下载一个新版本的`Sinatra`应用程序。我们还将创建一个运行`Redis`数据库的镜像和容器。  
之后，要利用`Docker`的特性来关联两个容器。

升级Sinatra应用程序，使用webapp_redis目录（与webapp目录相比，只有./lib/app.rb文件增加了对redis的支持）

```bash
chmod +x webapp_redis/bin/webapp  # 保证webapp_redis/bin/webapp 这个文件可以执行
```

## 构建Redis数据库镜像

```bash
cd redis
docker build -t mlin/redis .
# Sending build context to Docker daemon  2.048kB
# Step 1/7 : FROM ubuntu:18.04
#  ---> 5a214d77f5d7
# Step 2/7 : LABEL maintainer="mlin@mlin.com"
#  ---> Using cache
#  ---> e45487a19fa1
# Step 3/7 : ENV REFRESHED_AT 2014-06-01
#  ---> Using cache
#  ---> c9bd1b2c4708
# Step 4/7 : RUN apt-get -yqq update && apt-get -yqq install redis-server redis-tools
#  ---> Running in 1a79c0b36a5a
# ... ...
# Removing intermediate container 1a79c0b36a5a
#  ---> 1ae5711e4de2
# Step 5/7 : EXPOSE 6379
#  ---> Running in d33142141d9d
# Removing intermediate container d33142141d9d
#  ---> 79d56c7c0bca
# Step 6/7 : ENTRYPOINT ["/usr/bin/redis-server" ]
#  ---> Running in 8ecdf3bf8659
# Removing intermediate container 8ecdf3bf8659
#  ---> aeca5e9b44f6
# Step 7/7 : CMD []
#  ---> Running in a788b26fae16
# Removing intermediate container a788b26fae16
#  ---> 8fa24281eb1c
# Successfully built 8fa24281eb1c
# Successfully tagged mlin/redis:latest

cd ..
```

## 启动Redis容器

```bash
docker run -d -p 6379 --name redis mlin/redis
# eb89e0472ad9823f961c5b788d68c87a8863154e84a3b7ee46ee76bf70a61763
```

## 检查Redis容器

```bash
docker ps -a
# CONTAINER ID   IMAGE          COMMAND                  CREATED          STATUS          PORTS                     NAMES
# eb89e0472ad9   mlin/redis     "/usr/bin/redis-serv…"   20 seconds ago   Up 19 seconds   0.0.0.0:49156->6379/tcp   redis

docker port redis 6379
# 0.0.0.0:49156
```

## 测试Redis容器

```bash
yum install -y -q redis          # 安装redis客户端，Debian: apt-get install -y redis-tools
redis-cli -h 127.0.0.1 -p 49156  # 测试Redis连接
# 127.0.0.1:49156> 
```

## 将Sinatra应用程序连接到Redis容器

## 创建Docker网络

```bash
docker network create app   # 创建一个命名为app的桥接网络
# eef4822765313a1933f386eb07bda2d0f4f0b234f1a23dfcbdd0fd44879d0b13

docker network inspect app  # 查看app网络
# [
#     {
#         "Name": "app",
#         "Id": "eef4822765313a1933f386eb07bda2d0f4f0b234f1a23dfcbdd0fd44879d0b13",
#         "Created": "2021-11-19T01:23:03.667334591+01:00",
#         "Scope": "local",
#         "Driver": "bridge",
#         "EnableIPv6": false,
#         "IPAM": {
#             "Driver": "default",
#             "Options": {},
#             "Config": [
#                 {
#                     "Subnet": "172.18.0.0/16",
#                     "Gateway": "172.18.0.1"
#                 }
#             ]
#         },
#         "Internal": false,
#         "Attachable": false,
#         "Ingress": false,
#         "ConfigFrom": {
#             "Network": ""
#         },
#         "ConfigOnly": false,
#         "Containers": {},
#         "Options": {},
#         "Labels": {}
#     }
# ]

docker network ls  # 查看当前系统中的所有网络
# NETWORK ID     NAME      DRIVER    SCOPE
# eef482276531   app       bridge    local
# 512cca64d8b4   bridge    bridge    local
# 1ba3ba62a8c6   host      host      local
# 20479bbf075c   none      null      local
```

## 在Docker网络中创建Redis容器

```bash
docker run -d --net=app --name db mlin/redis
# 14245fdd7b6a2d48fb111fa963ceb73184c2307452fb6709ddfac0685cb56227

docker network inspect app  # 更新后的app网络，查看Containers下的信息
# [
#     {
#         "Name": "app",
#         "Id": "eef4822765313a1933f386eb07bda2d0f4f0b234f1a23dfcbdd0fd44879d0b13",
#         "Created": "2021-11-19T01:23:03.667334591+01:00",
#         "Scope": "local",
#         "Driver": "bridge",
#         "EnableIPv6": false,
#         "IPAM": {
#             "Driver": "default",
#             "Options": {},
#             "Config": [
#                 {
#                     "Subnet": "172.18.0.0/16",
#                     "Gateway": "172.18.0.1"
#                 }
#             ]
#         },
#         "Internal": false,
#         "Attachable": false,
#         "Ingress": false,
#         "ConfigFrom": {
#             "Network": ""
#         },
#         "ConfigOnly": false,
#         "Containers": {
#             "14245fdd7b6a2d48fb111fa963ceb73184c2307452fb6709ddfac0685cb56227": {
#                 "Name": "db",
#                 "EndpointID": "fdf4c487b2e5c4482ea55a0f588c5190ada228613d1e3fd513fcb554b69f6ef2",
#                 "MacAddress": "02:42:ac:12:00:02",
#                 "IPv4Address": "172.18.0.2/16",
#                 "IPv6Address": ""
#             }
#         },
#         "Options": {},
#         "Labels": {}
#     }
# ]
```

## 链接Redis容器，创建另一个webapp容器

```bash
docker run -p 4567 --net=app --name webapp_redis -it -v $PWD/webapp_redis:/opt/webapp mlin/sinatra /bin/bash
# root@6f6bab86098d:/#

docker network inspect -f '{{ .Containers }}' app  # 需要另启动一个shell来执行
# map[14245fdd7b6a2d48fb111fa963ceb73184c2307452fb6709ddfac0685cb56227:{db fdf4c487b2e5c4482ea55a0f588c5190ada228613d1e3fd513fcb554b69f6ef2 02:42:ac:12:00:02 172.18.0.2/16 }
#     6f6bab86098de262ec1a4ed7e3e662fdb44c398cd79e909c5b20469b711bde39:{webapp_redis a334a55b614bfc6ed77236333de0afd7965f508c05fd9a1493fe23a3c5b16c37 02:42:ac:12:00:03 172.18.0.3/16 }]
```

## 检查容器的网络

我们在`app`网络下启动了一个名为`webapp_redis`的容器。我们以交互的方式启动了这个容器，以便我们可以进入里面看看它内部发生了什么。
由于这个容器是在`app`网络内部启动的，因此`Docker`将会感知到所有在这个网络下运行的容器，并且通过`/etc/hosts`文件将这些容器的地址保存到本地`DNS`中。

```bash
# 下面命令在容器webapp_redis中执行
apt-get update -yqq && apt-get install -y iputils-ping dnsutils
cat /etc/hosts          # 没有查询到db与db.app的A记录，与书中不同，应该是Docker版本的原因
# 127.0.0.1       localhost
# ::1     localhost ip6-localhost ip6-loopback
# fe00::0 ip6-localnet
# ff00::0 ip6-mcastprefix
# ff02::1 ip6-allnodes
# ff02::2 ip6-allrouters
# 172.18.0.3      6f6bab86098d

dig -t a db +short      # 但是能够解析出来，怀疑是Docker的network抽象出来了一个dns server
# 172.18.0.2
dig -t a db.app +short
# 172.18.0.2
cat /etc/resolv.conf
# nameserver 127.0.0.11
# options ndots:0

ping db.app             # 除了db之外还有db.app的A记录，这里app是网络名，即dockername.dockernetwork
# PING db.app (172.18.0.2) 56(84) bytes of data.
# 64 bytes from db.app (172.18.0.2): icmp_seq=1 ttl=64 time=0.365 ms
# 64 bytes from db.app (172.18.0.2): icmp_seq=2 ttl=64 time=0.069 ms

# webapp_redis/lib/app.rb 中引用的也是 db：redis = Redis.new(:host => 'db', :port => '6379')
```

## 在容器内启动Sinatra应用程序

```bash
nohup /opt/webapp/bin/webapp &
# [1] 520
# nohup: ignoring input and appending output to 'nohup.out'
```

## 检查并测试启用了Redis的Sinatra应用程序

```bash
docker port webapp_redis 4567
# 0.0.0.0:49159
curl -i -H 'Accept: application/json' -d 'name=Foo&status=Bar' http://localhost:49159/json
# HTTP/1.1 200 OK 
# Content-Type: text/html;charset=utf-8
# Content-Length: 29
# X-Xss-Protection: 1; mode=block
# X-Content-Type-Options: nosniff
# X-Frame-Options: SAMEORIGIN
# Server: WEBrick/1.4.2 (Ruby/2.5.1/2018-03-29)
# Date: Mon, 06 Dec 2021 00:56:15 GMT
# Connection: Keep-Alive
# 
# {"name":"Foo","status":"Bar"}

curl -i http://localhost:49159/json
# HTTP/1.1 200 OK 
# Content-Type: text/html;charset=utf-8
# Content-Length: 41
# X-Xss-Protection: 1; mode=block
# X-Content-Type-Options: nosniff
# X-Frame-Options: SAMEORIGIN
# Server: WEBrick/1.4.2 (Ruby/2.5.1/2018-03-29)
# Date: Mon, 06 Dec 2021 01:04:12 GMT
# Connection: Keep-Alive
# 
# "[{\"name\":\"Foo\",\"status\":\"Bar\"}]"
```

## 将已有的容器连接到Docker网络

一个容器可以同时隶属于多个Dcoker网络，所以可以创建非常复杂的网络模型。

```bash
docker ps -a
# CONTAINER ID   IMAGE          COMMAND                  CREATED          STATUS                  PORTS                     NAMES
# 6f6bab86098d   mlin/sinatra   "/bin/bash"              48 minutes ago   Up 48 minutes           0.0.0.0:49159->4567/tcp   webapp_redis
# 14245fdd7b6a   mlin/redis     "/usr/bin/redis-serv…"   4 days ago       Up 15 minutes           6379/tcp                  db
# eb89e0472ad9   mlin/redis     "/usr/bin/redis-serv…"   5 days ago       Up 4 days               0.0.0.0:49157->6379/tcp   redis
# 729fa1b3d04b   mlin/sinatra   "/opt/webapp/bin/web…"   5 days ago       Up 5 days               0.0.0.0:49155->4567/tcp   webapp

docker network inspect -f '{{ .Containers }}' app
# map[14245fdd7b6a2d48fb111fa963ceb73184c2307452fb6709ddfac0685cb56227:{db fdf4c487b2e5c4482ea55a0f588c5190ada228613d1e3fd513fcb554b69f6ef2 02:42:ac:12:00:02 172.18.0.2/16 }
#     6f6bab86098de262ec1a4ed7e3e662fdb44c398cd79e909c5b20469b711bde39:{webapp_redis a334a55b614bfc6ed77236333de0afd7965f508c05fd9a1493fe23a3c5b16c37 02:42:ac:12:00:03 172.18.0.3/16 }]

docker network connect app redis     # 添加已有容器（redis）到app网络
docker network inspect -f '{{ .Containers }}' app
# map[14245fdd7b6a2d48fb111fa963ceb73184c2307452fb6709ddfac0685cb56227:{db e8595ff4bcc1b72ce794ad51d7ab98300b38ce42749de1d61428cda7f583713d 02:42:ac:12:00:02 172.18.0.2/16 }
#     6f6bab86098de262ec1a4ed7e3e662fdb44c398cd79e909c5b20469b711bde39:{webapp_redis a334a55b614bfc6ed77236333de0afd7965f508c05fd9a1493fe23a3c5b16c37 02:42:ac:12:00:03 172.18.0.3/16 }
#     eb89e0472ad9823f961c5b788d68c87a8863154e84a3b7ee46ee76bf70a61763:{redis 3ed1523519ba8ffa2ccdafecc723d1775bd9453465c01c2480fdd26904b891b6 02:42:ac:12:00:04 172.18.0.4/16 }]

docker network disconnect app redis  # 从app网络中断开redis容器
docker network inspect -f '{{ .Containers }}' app
# map[14245fdd7b6a2d48fb111fa963ceb73184c2307452fb6709ddfac0685cb56227:{db e8595ff4bcc1b72ce794ad51d7ab98300b38ce42749de1d61428cda7f583713d 02:42:ac:12:00:02 172.18.0.2/16 }
#     6f6bab86098de262ec1a4ed7e3e662fdb44c398cd79e909c5b20469b711bde39:{webapp_redis a334a55b614bfc6ed77236333de0afd7965f508c05fd9a1493fe23a3c5b16c37 02:42:ac:12:00:03 172.18.0.3/16 }]
```
