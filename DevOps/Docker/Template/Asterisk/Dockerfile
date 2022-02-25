# Version 0.0.1
FROM centos:7
LABEL maintainer="michaelbrucelin@gmail.com"

RUN yum -y install epel-release && \
    yum -y install wget gcc gcc-c++ make ncurses-devel libuuid-devel libcurl-devel jansson-devel libxml2-devel sqlite-devel \
    unixODBC unixODBC-devel libtool-ltdl libtool-ltdl-devel && \
    yum clean all && \
    rm -rf /var/cache/yum/*

RUN cd /usr/local/ && \
    wget https://downloads.asterisk.org/pub/telephony/asterisk/old-releases/asterisk-13.38.3.tar.gz && \
    tar -zxvf asterisk-13.38.3.tar.gz && \
    cd /usr/local/asterisk-13.38.3 && \
    ./configure && \
    make menuselect.makeopts && \
    menuselect/menuselect --enable chan_ooh323 menuselect.makeopts && \
    make && \
    make install && \
    make samples && \
    # make config && \
    # make dist-clean && \
    cd /usr/local/ && \
    rm -rf asterisk-13.38.3 asterisk-13.38.3.tar.gz && \
    cd /usr/lib/asterisk/modules && \
    wget http://asterisk.hosting.lv/bin/codec_g729-ast130-gcc4-glibc2.2-x86_64-core2-sse4.so && \
    wget http://asterisk.hosting.lv/bin/codec_g723-ast130-gcc4-glibc2.2-x86_64-core2-sse4.so && \
    cd /etc/asterisk/ && \
    mv /etc/asterisk/sip.conf /etc/asterisk/sip.conf.bak && \
    mv /etc/asterisk/rtp.conf /etc/asterisk/rtp.conf.bak && \
    mv /etc/asterisk/extensions.conf /etc/asterisk/extensions.conf.bak

EXPOSE 5060/tcp 5060/udp 10000-10099/udp

VOLUME ["/etc/asterisk", "/var/log/asterisk"]

WORKDIR /root/

# ENTRYPOINT ["/etc/init.d/asterisk", "start"]
ENTRYPOINT ["/usr/sbin/asterisk", "-fpvvvvvvvvvv"]
