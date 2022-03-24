# Sofia-SIP

## 介绍

Sofia-SIP is an open-source SIP User-Agent library, compliant with the IETF RFC3261 specification.  
Sofia-SIP 是一个开源的 SIP 用户代理库，符合 IETF RFC3261 规范。

## 项目

[http://sofia-sip.sourceforge.net/](http://sofia-sip.sourceforge.net/)  
[https://github.com/freeswitch/sofia-sip](https://github.com/freeswitch/sofia-sip)

## 安装

Debian11

```bash
apt-get install sofia-sip-bin
```

CentOS7
> CentOS7 yum源中没有相应的包，epel源中也没有，这里没有编译安装，也没有安装其它yum源，而是直接找了rpm包  
> `https://centos.pkgs.org/7/okey-x86_64/sofia-sip-1.13.6-1.el7.x86_64.rpm.html`  
> `https://centos.pkgs.org/7/okey-x86_64/sofia-sip-utils-1.13.6-1.el7.x86_64.rpm.html`

```bash
yum install -y openssl11-libs
rpm -ivh sofia-sip-1.13.6-1.el7.x86_64.rpm
rpm -ivh sofia-sip-utils-1.13.6-1.el7.x86_64.rpm

# or
yum install -y ./sofia-sip-1.13.6-1.el7.x86_64.rpm
yum install -y ./sofia-sip-utils-1.13.6-1.el7.x86_64.rpm

# or
yum install -y http://repo.okay.com.mx/centos/7/x86_64/release/sofia-sip-1.13.6-1.el7.x86_64.rpm
yum install -y http://repo.okay.com.mx/centos/7/x86_64/release/sofia-sip-utils-1.13.6-1.el7.x86_64.rpm

rpm -ql sofia-sip-utils
> /usr/bin/addrinfo
> /usr/bin/localinfo
> /usr/bin/sip-date
> /usr/bin/sip-dig
> /usr/bin/sip-options
> /usr/bin/stunc
```

## 示例

```bash
# sip-options sip:AsteriskIP:5060
SIP/2.0 200 OK
To: <sip:111.111.111.111>;tag=as5d1c9cc6
Server: Asterisk PBX 13.38.3
Allow: INVITE, ACK, CANCEL, OPTIONS, BYE, REFER, SUBSCRIBE, NOTIFY, INFO, PUBLISH, MESSAGE
Supported: replaces, timer
Contact: <sip:111.111.111.111:5060>
Accept: application/sdp

# sip-options sip:KamailioIP:5060
SIP/2.0 200 Keepalive
To: <sip:111.111.111.111>;tag=8eb83802033ad9f8d199b965287b344d.ba3726bc
Server: kamailio (5.5.2 (x86_64/linux))

# sip-options sip:VOS3000IP:5060
SIP/2.0 200 OK
To: <sip:111.111.111.111>

# sip-options sip:VOS5000IP:5060
SIP/2.0 200 OK
To: <sip:111.111.111.111>

# sip-options sip:SBCIP:5060
SIP/2.0 200 OK
To: <sip:111.111.111.111>;tag=sbcsipuas_1_257436_20220315050532835_ucs01sb05
Server: sbc_5

# sip-options sip:XXXIP:5060
SIP/2.0 200 OK
To: <sip:111.111.111.111>;tag=6eaf47f9abe595bf14fd1aa973910075.8002
Server: Very Nice SIP v2020-PRODUCTION.341

# Asterisk服务无响应
# sip-options sip:127.0.0.1:5060
SIP/2.0 408 Request Timeout
To: sip:127.0.0.1;tag=vK1Kr3XgQ0QDj

#  Asterisk服务没启动
# sip-options sip:127.0.0.1:5066
SIP/2.0 503 Service Unavailable
To: sip:127.0.0.1;tag=cKZXjvpySBvDp

#  Asterisk服务正常
# sip-options sip:127.0.0.1:5060
SIP/2.0 200 OK
To: sip:127.0.0.1;tag=as5a298778
Server: Asterisk PBX 13.38.3
Allow: INVITE, ACK, CANCEL, OPTIONS, BYE, REFER, SUBSCRIBE, NOTIFY, INFO, PUBLISH, MESSAGE
Supported: replaces, timer
Contact: <sip:XXX.XXX.XXX.XXX:5060>
Accept: application/sdp
```
