FROM ubuntu:18.04
LABEL maintainer="mlin@mlin.com"
ENV REFRESHED_AT 2014-06-01

RUN apt-get -yqq update && apt-get -yqq install ruby ruby-dev build-essential redis-tools
RUN gem install --no-rdoc --no-ri sinatra json redis

# 创建目录用来存放新的Web应用程序
RUN mkdir -p /opt/webapp

EXPOSE 4567

# Web应用程序的启动文件
CMD [ "/opt/webapp/bin/webapp" ]
