FROM ubuntu:18.04
LABEL maintainer="mlin@mlin.com"
ENV REFRESHED_AT 2016-06-01

RUN apt-get -yqq update
RUN apt-get -yqq install ruby ruby-dev libffi-dev build-essential nodejs
RUN gem install --no-rdoc --no-ri jekyll -v 2.5.3

# 用来存放网站的源代码
VOLUME /data
# 用来存放编译后的Jekyll网站码
VOLUME /var/www/html
# 将工作目录设置到/data/
WORKDIR /data

# 自动构建，将工作目录/data/中的所有的Jekyll网站代码构建到/var/www/html/目录中
ENTRYPOINT [ "jekyll", "build", "--destination=/var/www/html" ]
