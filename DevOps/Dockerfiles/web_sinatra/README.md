# 使用Docker构建并测试Web应用程序

这个示例测试一个Web应用程序。这里测试一个基于`Sinatra`的`Web`应用程序，而不是静态网站，然后我们将基于`Docker`来对这个应用进行测试。  
`Sinatra`是一个基于`Ruby`的`Web`应用框架，它包含一个Web应用库，以及简单的领域专用语言（即`DSL`）来构建`Web`应用程序。  
与其他复杂的`Web`应用框架（如`Ruby on Rails`）不同，`Sinatra`并不遵循`MVC`模式，而关注于让开发者创建快速、简单的`Web`应用。  
因此，`Sinatra`非常适合用来创建一个小型的示例应用进行测试。

这里我们将创建一个应用程序，它接收输入的`URL`参数，并以`JSON`散列的结构输出到客户端。这里也将展示一下如何将`Docker`容器链接起来。

## 构建新的Sinatra镜像

```bash
docker build -t mlin/sinatra .
# Sending build context to Docker daemon  2.048kB
# Step 1/8 : FROM ubuntu:18.04
#  ---> 5a214d77f5d7
# Step 2/8 : LABEL maintainer="mlin@mlin.com"
#  ---> Using cache
#  ---> 5c9b0a03ca63
# Step 3/8 : ENV REFRESHED_AT 2014-06-01
#  ---> Using cache
#  ---> 0712271ad588
# Step 4/8 : RUN apt-get -yqq update && apt-get -yqq install ruby ruby-dev build-essential redis-tools
#  ---> Running in 857bc82ce947
# ... ...
# Removing intermediate container 857bc82ce947
#  ---> 58d9a523aa5a
# Step 5/8 : RUN gem install --no-rdoc --no-ri sinatra json redis
#  ---> Running in 2e595f9d5711
# Successfully installed rack-2.2.3
# ... ...
# Successfully installed redis-4.5.1
# 8 gems installed
# Removing intermediate container 2e595f9d5711
#  ---> 63d309d2429e
# Step 6/8 : RUN mkdir -p /opt/webapp
#  ---> Running in b03f2798ded2
# Removing intermediate container b03f2798ded2
#  ---> ef8bcc1e4f32
# Step 7/8 : EXPOSE 4567
#  ---> Running in 41df55c2d1f4
# Removing intermediate container 41df55c2d1f4
#  ---> a535db034172
# Step 8/8 : CMD [ "/opt/webapp/bin/webapp" ]
#  ---> Running in 0246bb630afd
# Removing intermediate container 0246bb630afd
#  ---> f520b5a3e0fa
# Successfully built f520b5a3e0fa
# Successfully tagged mlin/sinatra:latest
```

## 启动第一个Sinatra容器

```bash
chmod +x webapp/bin/webapp  # 保证webapp/bin/webapp 这个文件可以执行
docker run -d -p 4567 --name webapp -v $PWD/webapp:/opt/webapp mlin/sinatra
# 69508e55743c7ded248040b384cf33f6326ddc007e4e1272d76c45a5d0e16ef9
```

## 检查Sinatra容器

```bash
docker logs webapp       # 检查Sinatra容器的日志
# [2021-11-17 00:34:31] INFO  WEBrick 1.4.2
# [2021-11-17 00:34:31] INFO  ruby 2.5.1 (2018-03-29) [x86_64-linux-gnu]
# == Sinatra (v2.1.0) has taken the stage on 4567 for development with backup from WEBrick
# [2021-11-17 00:34:31] INFO  WEBrick::HTTPServer#start: pid=1 port=4567

docker logs -f webapp    # 持续跟踪Sinatra容器的日志

docker top webapp        # 列出Sinatra进程
UID     PID      PPID     C    STIME    TTY    TIME        CMD
root    18520    18501    0    00:34    ?      00:00:00    /usr/bin/ruby /opt/webapp/bin/webapp

docker port webapp 4567  # 检查Sinatra的端口映射
# 0.0.0.0:49154
```

## 测试Sinatra应用程序

```bash
curl -i -H 'Accept: application/json' -d 'name=Foo&status=Bar' http://localhost:49154/json
# HTTP/1.1 200 OK 
# Content-Type: text/html;charset=utf-8
# Content-Length: 29
# X-Xss-Protection: 1; mode=block
# X-Content-Type-Options: nosniff
# X-Frame-Options: SAMEORIGIN
# Server: WEBrick/1.4.2 (Ruby/2.5.1/2018-03-29)
# Date: Wed, 17 Nov 2021 00:48:08 GMT
# Connection: Keep-Alive
# 
# {"name":"Foo","status":"Bar"}
```
