# Version 0.0.1
FROM centos:7
LABEL maintainer="michaelbrucelin@gmail.com"

RUN yum -y install epel-release && \
    yum -y install wget gcc gcc-c++ ncurses-devel libuuid-devel libcurl-devel jansson-devel libxml2-devel sqlite-devel \
                   install unixODBC unixODBC-devel libtool-ltdl libtool-ltdl-devel


# 开放端口，udp 10000-20000？:w
