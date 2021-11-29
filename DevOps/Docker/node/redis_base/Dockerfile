FROM ubuntu:18.04
LABEL maintainer="mlin@mlin.com"
ENV REFRESHED_AT 2017-06-01

RUN apt-get -yqq update
# 安装最新版本的Redis（从PPA库安装，而不是使用Ubuntu自带的较老的Redis包）
RUN apt-get install -yqq software-properties-common
RUN add-apt-repository ppa:chris-lea/redis-server
RUN apt-get -yqq update
RUN apt-get -yqq install redis-server redis-tools

VOLUME [ "/var/lib/redis", "/var/log/redis" ]

EXPOSE 6379

# 因为不会执行这个镜像，所以没有包含ENTRYPOINT或者CMD指令，我们只是基于这个镜像构建别的镜像。
CMD []
