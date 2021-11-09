FROM ubuntu:18.04
LABEL maintainer="mlin@mlin.com"
ENV REFRESHED_AT 2014-06-01

# 安装nginx
RUN apt-get -qq update && apt-get -qq install nginx

# 在容器中创建一个目录/var/www/html/website/
RUN mkdir -p /var/www/html/website
# 将本地的Nginx配置文件添加到镜像中
ADD nginx/global.conf /etc/nginx/conf.d/
ADD nginx/nginx.conf /etc/nginx/

# 公开镜像的80端口
EXPOSE 80
