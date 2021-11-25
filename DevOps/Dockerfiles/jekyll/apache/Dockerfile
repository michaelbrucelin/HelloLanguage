FROM ubuntu:18.04
LABEL maintainer="mlin@mlin.com"

RUN apt-get -yqq update
RUN apt-get -yqq install apache2

# 创建卷/var/www/html/，用来存放编译后的Jekyll网站
VOLUME [ "/var/www/html" ]
# 将/var/www/html设为工作目录
WORKDIR /var/www/html

# 设置了一些必要的环境变量
ENV APACHE_RUN_USER www-data
ENV APACHE_RUN_GROUP www-data
ENV APACHE_LOG_DIR /var/log/apache2
ENV APACHE_PID_FILE /var/run/apache2.pid
ENV APACHE_RUN_DIR /var/run/apache2
ENV APACHE_LOCK_DIR /var/lock/apache2

# 创建了必要的目录
RUN mkdir -p $APACHE_RUN_DIR $APACHE_LOCK_DIR $APACHE_LOG_DIR

EXPOSE 80

# 使用ENTRYPOINT和CMD指令组合来在容器启动时默认运行Apache
ENTRYPOINT [ "/usr/sbin/apachectl" ]
CMD ["-D", "FOREGROUND"]
