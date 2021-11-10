# 这个Nginx配置文件是为了运行Sample网站而配置的

FROM ubuntu:18.04
LABEL maintainer="mlin@mlin.com"
ENV REFRESHED_AT 2014-06-01

# 安装nginx
RUN apt-get -yqq update && apt-get -yqq install nginx

# 在容器中创建一个目录/var/www/html/website/
RUN mkdir -p /var/www/html/website
# 将本地的Nginx配置文件添加到镜像中
# 其中第一个指令给的目标目录，第2个指令给的是目标文件，两种形式都是允许的
ADD nginx/global.conf /etc/nginx/conf.d/
ADD nginx/nginx.conf /etc/nginx/nginx.conf

# 公开镜像的80端口
EXPOSE 80
