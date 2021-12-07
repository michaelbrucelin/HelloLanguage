FROM ubuntu:18.04
LABEL maintainer="mlin@mlin.com"
ENV REFRESHED_AT 2016-06-01

RUN apt-get -yqq update
RUN apt-get -yqq install nodejs npm
RUN mkdir -p /var/log/nodeapp

# 将nodeapp的源代码添加到/opt/nodeapp目录
# 这个Node.js应用是一个简单的Express服务器，包括一个存放应用依赖信息的package.json文件和包含实际应用代码的server.js文件
ADD nodeapp /opt/nodeapp/

# 将工作目录设置为/opt/nodeapp
WORKDIR /opt/nodeapp
# 安装了Node应用的必要软件包
RUN npm install

# 创建用于存放Node应用日志的卷/var/log/nodeapp
VOLUME [ "/var/log/nodeapp" ]

EXPOSE 3000

ENTRYPOINT [ "nodejs", "server.js" ]
