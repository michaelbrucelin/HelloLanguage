FROM ubuntu:18.04
LABEL maintainer="mlin@mlin.com"
ENV REFRESHED_AT 2016-06-01

# 安装Java JDK和Tomcat服务器
RUN apt-get -yqq update
RUN apt-get -yqq install tomcat8 default-jdk

# 指定一些启动Tomcat需要的环境变量
ENV CATALINA_HOME /usr/share/tomcat8
ENV CATALINA_BASE /var/lib/tomcat8
ENV CATALINA_PID /var/run/tomcat8.pid
ENV CATALINA_SH /usr/share/tomcat8/bin/catalina.sh
ENV CATALINA_TMPDIR /tmp/tomcat8-tomcat8-tmp

# 创建一个临时目录
RUN mkdir -p $CATALINA_TMPDIR

# 创建了/var/lib/tomcat8/webapps/卷
VOLUME [ "/var/lib/tomcat8/webapps/" ]

EXPOSE 8080

# 启动Tomcat
ENTRYPOINT [ "/usr/share/tomcat8/bin/catalina.sh", "run" ]
