FROM ubuntu:18.04
LABEL maintainer="mlin@mlin.com"
ENV REFRESHED_AT 2016-06-01

RUN apt-get -yqq update
RUN apt-get -yqq install wget

VOLUME [ "/var/lib/tomcat8/webapps/" ]
WORKDIR /var/lib/tomcat8/webapps/

ENTRYPOINT [ "wget" ]
CMD [ "--help" ]
