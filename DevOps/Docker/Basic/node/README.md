# 多容器的应用栈

这个服务应用的示例中我们把一个使用`Express`框架的、带有`Redis`后端的`Node.js`应用完全`Docker`化了。  
在这个例子中，我们会构建一系列的镜像来支持部署多容器的应用。

- 一个Node容器，用来服务于`Node`应用，这个容器会链接到。
- 一个`Redis`主容器，用于保存和集群化应用状态，这个容器会链接到。
- 两个`Redis`副本容器，用于集群化应用状态。
- 一个日志容器，用于捕获应用日志。

我们的`Node`应用程序会运行在一个容器中，它后面会有一个配置为“主-副本”模式运行在多个容器中的`Redis`集群。

## Node.js镜像

构建一个安装了`Node.js`的镜像，这个镜像有`Express`应用和相应的必要的软件包。

```bash
cd nodejs
docker build -t mlin/nodejs .  # 构建Node.js镜像
# Sending build context to Docker daemon  6.656kB
# Step 1/12 : FROM ubuntu:18.04
#  ---> 5a214d77f5d7
# ... ...
# Step 12/12 : ENTRYPOINT [ "nodejs", "server.js" ]
#  ---> Running in c04b44e772f7
# Removing intermediate container c04b44e772f7
#  ---> 8f919773b4d6
# Successfully built 8f919773b4d6
# Successfully tagged mlin/nodejs:latest
```

## Redis基础镜像

构建第一个`Redis`镜像：安装`Redis`的基础镜像，然后使用这个镜像构建`Redis`主镜像和副本镜像。

```bash
cd ../redis_base
docker build -t mlin/redis_base .
# Sending build context to Docker daemon  2.048kB
# Step 1/11 : FROM ubuntu:18.04
#  ---> 5a214d77f5d7
# ... ...
# Step 11/11 : CMD []
#  ---> Running in 2264b5f669c5
# Removing intermediate container 2264b5f669c5
#  ---> 6696de33a87d
# Successfully built 6696de33a87d
# Successfully tagged mlin/redis_base:latest
```

## Redis主镜像

`Redis`主服务器。

```bash
cd ../redis_primary
docker build -t mlin/redis_primary .
# Sending build context to Docker daemon  2.048kB
# Step 1/4 : FROM mlin/redis_base
#  ---> 6696de33a87d
# Step 2/4 : LABEL maintainer="mlin@mlin.com"
#  ---> Running in 6005de016bf1
# Removing intermediate container 6005de016bf1
#  ---> dc9cbdaad5ee
# Step 3/4 : ENV REFRESHED_AT 2016-06-01
#  ---> Running in 22d2ed5ded6e
# Removing intermediate container 22d2ed5ded6e
#  ---> 4c9b7be4e525
# Step 4/4 : ENTRYPOINT [ "redis-server", "--protected-mode no", "--logfile /var/log/redis/redis-server.log" ]
#  ---> Running in beb800b648d9
# Removing intermediate container beb800b648d9
#  ---> 23ed37ecc679
# Successfully built 23ed37ecc679
# Successfully tagged mlin/redis_primary:latest
```

## Redis副本镜像

创建`Redis`副本镜像，保证为`Node.js`应用提供`Redis`服务的冗余度。

```bash
cd ../redis_replica
docker build -t mlin/redis_replica .
# Sending build context to Docker daemon  2.048kB
# Step 1/4 : FROM mlin/redis_base
#  ---> 6696de33a87d
# Step 2/4 : LABEL maintainer="mlin@mlin.com"
#  ---> Using cache
#  ---> dc9cbdaad5ee
# Step 3/4 : ENV REFRESHED_AT 2016-06-01
#  ---> Using cache
#  ---> 4c9b7be4e525
# Step 4/4 : ENTRYPOINT [ "redis-server", "--protected-mode no", "--logfile /var/log/redis/redis-replica.log", "--slaveof redis_primary 6379" ]
#  ---> Running in e24e12ecc6f7
# Removing intermediate container e24e12ecc6f7
#  ---> bde06c593d40
# Successfully built bde06c593d40
# Successfully tagged mlin/redis_replica:latest
```

## 创建Redis后端集群

```bash
# 创建express网络，用来运行Express应用程序
docker network create express
# 869db1249f1585f2730863dc484e29a1c1e4e42ef88656cc5fe02c14bc1ff160

# 这个网络中运行Redis主容器
# -h标志用来设置容器的主机名，这会覆盖默认的行为，默认将容器的主机名设置为容器ID
docker run -d -h redis_primary --net express --name redis_primary mlin/redis_primary
# 030c1666c8da58bac57561487efe8bf386873fa4ffbf49fac42a7a084743eaed

docker logs redis_primary  # Redis服务会将日志记录到一个文件而不是记录到标准输出，所以使用Docker查看不到任何日志
docker run -it --rm --volumes-from redis_primary ubuntu cat /var/log/redis/redis-server.log
# 1:C 29 Nov 2021 05:12:08.135 # oO0OoO0OoO0Oo Redis is starting oO0OoO0OoO0Oo
# 1:C 29 Nov 2021 05:12:08.136 # Redis version=6.0.6, bits=64, commit=00000000, modified=0, pid=1, just started
# 1:C 29 Nov 2021 05:12:08.136 # Configuration loaded
# 1:M 29 Nov 2021 05:12:08.138 * Running mode=standalone, port=6379.
# 1:M 29 Nov 2021 05:12:08.138 # Server initialized
# 1:M 29 Nov 2021 05:12:08.139 # WARNING overcommit_memory is set to 0! Background save may fail under low memory condition. To fix this issue add 'vm.overcommit_memory = 1' to /etc/sysctl.conf and then reboot or run the command 'sysctl vm.overcommit_memory=1' for this to take effect.
# 1:M 29 Nov 2021 05:12:08.139 # WARNING you have Transparent Huge Pages (THP) support enabled in your kernel. This will create latency and memory usage issues with Redis. To fix this issue run the command 'echo never > /sys/kernel/mm/transparent_hugepage/enabled' as root, and add it to your /etc/rc.local in order to retain the setting after a reboot. Redis must be restarted after THP is disabled.
# 1:M 29 Nov 2021 05:12:08.141 * Ready to accept connections

# 运行第一个Redis副本容器
docker run -d -h redis_replica1 --name redis_replica1 --net express mlin/redis_replica
# 56433bfde872d317936953998da1ba2a13f4d4fc7d9bb84fd45e34f39c5812fd

docker run -it --rm --volumes-from redis_replica1 ubuntu cat /var/log/redis/redis-replica.log
# 1:C 29 Nov 2021 05:27:18.453 # oO0OoO0OoO0Oo Redis is starting oO0OoO0OoO0Oo
# ... ...
# 1:S 29 Nov 2021 05:27:18.663 * Full resync from master: 4ce5441216f45b01f4c7691e76d19b33f7907ea3:0
# 1:S 29 Nov 2021 05:27:18.731 * MASTER <-> REPLICA sync: receiving 175 bytes from master to disk
# 1:S 29 Nov 2021 05:27:18.731 * MASTER <-> REPLICA sync: Flushing old data
# 1:S 29 Nov 2021 05:27:18.731 * MASTER <-> REPLICA sync: Loading DB in memory
# 1:S 29 Nov 2021 05:27:18.732 * Loading RDB produced by version 6.0.6
# 1:S 29 Nov 2021 05:27:18.732 * RDB age 0 seconds
# 1:S 29 Nov 2021 05:27:18.732 * RDB memory usage when created 1.82 Mb
# 1:S 29 Nov 2021 05:27:18.732 * MASTER <-> REPLICA sync: Finished with success

# 运行第二个Redis副本容器
docker run -d -h redis_replica2 --name redis_replica2 --net express mlin/redis_replica
# 9fb88585875052b9c8d237f46e3c634339e0e7a4c7409c2289e544e91d377c1c

docker run -it --rm --volumes-from redis_replica2 ubuntu cat /var/log/redis/redis-replica.log
# 1:C 29 Nov 2021 05:30:57.361 # oO0OoO0OoO0Oo Redis is starting oO0OoO0OoO0Oo
# ... ...
# 1:S 29 Nov 2021 05:30:57.385 * Full resync from master: 4ce5441216f45b01f4c7691e76d19b33f7907ea3:308
# 1:S 29 Nov 2021 05:30:57.492 * MASTER <-> REPLICA sync: receiving 176 bytes from master to disk
# 1:S 29 Nov 2021 05:30:57.492 * MASTER <-> REPLICA sync: Flushing old data
# 1:S 29 Nov 2021 05:30:57.493 * MASTER <-> REPLICA sync: Loading DB in memory
# 1:S 29 Nov 2021 05:30:57.493 * Loading RDB produced by version 6.0.6
# 1:S 29 Nov 2021 05:30:57.493 * RDB age 0 seconds
# 1:S 29 Nov 2021 05:30:57.493 * RDB memory usage when created 1.88 Mb
# 1:S 29 Nov 2021 05:30:57.493 * MASTER <-> REPLICA sync: Finished with success
```

## 创建Node容器

```bash
docker run -d --name mlin_nodeapp -p 3000:3000 --net express mlin/nodejs
# 004615abad45b45c74eaec2514a1662d29da3753aa03c04672dafaa4c2f33143

docker logs mlin_nodeapp
# Listening on port 3000
```

## 测试Node应用

```bash
curl http://127.0.0.1:3000
# {"status":"ok"}
```

## 捕获应用日志

在生产环境里需要确保可以捕获日志并将日志保存到日志服务器。我们将使用`Logstash`来完成这件事。  
`Node`和`Redis`容器都将日志输出到`Logstash`。在生产环境中，这些事件会发到`Logstash`服务器并存储在`Elasticsearch`里。

```bash
# 构建Logstash镜像
cd ../logstash
docker build -t mlin/logstash .
# Sending build context to Docker daemon  3.584kB
# Step 1/13 : FROM ubuntu:18.04
#  ---> 5a214d77f5d7
# ... ...
# Step 13/13 : CMD [ "-f", "logstash.conf", "--config.reload.automatic" ]
#  ---> Running in db9ceec461e8
# Removing intermediate container db9ceec461e8
#  ---> 4728fe4e9299
# Successfully built 4728fe4e9299
# Successfully tagged mlin/logstash:latest

docker run -d --name mlin_logstash --volumes-from redis_primary --volumes-from mlin_nodeapp mlin/logstash
# a3ceed771a5149f43ee14e812383719ec24b813aff3be2a5b99763193e53281f

# logstash容器的日志
docker logs -f mlin_logstash
# WARNING: Could not find logstash.yml which is typically located in $LS_HOME/config or /etc/logstash. You can specify the path using --path.settings. Continuing using the defaults
# Could not find log4j2 configuration at path /usr/share/logstash/config/log4j2.properties. Using default config which logs errors to the console
打开另外一个shell，执行curl http://127.0.0.1:3000，可以看到下面的日志输出
# {
#       "@version" => "1",
#           "host" => "a3ceed771a51",
#           "path" => "/var/log/nodeapp/nodeapp.log",
#     "@timestamp" => 2021-11-29T05:51:32.554Z,
#        "message" => "::ffff:172.19.0.1 - - [29/Nov/2021:05:51:31 +0000] \"GET / HTTP/1.1\" 200 15 \"-\" \"curl/7.29.0\"",
#           "type" => "syslog"
# }
```
