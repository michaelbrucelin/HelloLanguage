# 配置CentOS5/6 yum源

示例中的yum源文件基于[https://vault.centos.org/](https://vault.centos.org/)制作，基本可信。  
下面示例中遇到的ssl问题，一个是安装了`ca-certificates`解决的，一个是安装了`ca-certificates`+`openssl`+`nss`解决的，  
而网上有有的地方说需要同时更新`yum`+`curl`+`openssl`+`nss`，这里记录一下，遇到问题再说。

## 示例1：配置CentOS6.8的yum源

首先安装CentOS6.8 minimal版本。

```bash
cd /etc/yum.repos.d
mv CentOS-Base.repo CentOS-Base.repo.bak
wget [--no-check-certificate] https://raw.githubusercontent.com/michaelbrucelin/HelloLanguage/main/DevOps/CentOSVault/CentOS6/CentOS-Base.repo
# curl -[k]o CentOS-Base.repo ... ...   # 没有wget的话可以使用curl命令，或者vi自己创建
sed -i 's/6.10/6.8/g' CentOS-Base.repo  # 更改yum源中的版本信息

# CentOS5
# wget https://raw.githubusercontent.com/michaelbrucelin/HelloLanguage/main/DevOps/CentOSVault/CentOS5/CentOS-Base.repo
# sed -i 's/5.11/5.8/g' CentOS-Base.repo

# 上述操作完成后，执行yum时提示证书错误，操作下面的命令
# 需要更新包：ca-certificates，测试必须使用CentOS6.10的ca-certificates包，使用6.8的无效
wget [--no-check-certificate] https://vault.centos.org/6.10/os/x86_64/Packages/ca-certificates-2018.2.22-65.1.el6.noarch.rpm
rpm -Uvh ca-certificates-2018.2.22-65.1.el6.noarch.rpm
```

## 示例2：配置CentOS6.5的yum源

首先安装CentOS6.5 minimal版本。

```bash
cd /etc/yum.repos.d
mv CentOS-Base.repo CentOS-Base.repo.bak
wget [--no-check-certificate] https://raw.githubusercontent.com/michaelbrucelin/HelloLanguage/main/DevOps/CentOSVault/CentOS6/CentOS-Base.repo
sed -i 's/6.10/6.5/g' CentOS-Base.repo  # 更改yum源中的版本信息

# 上述操作完成后，执行yum时提示证书错误，操作下面的命令
# 需要更新包：ca-certificates，测试必须使用CentOS6.10的ca-certificates包，使用6.8的无效
wget [--no-check-certificate] https://vault.centos.org/6.10/os/x86_64/Packages/ca-certificates-2018.2.22-65.1.el6.noarch.rpm
rpm -Uvh ca-certificates-2018.2.22-65.1.el6.noarch.rpm

# 上述操作完成后，执行yum仍然提示证书错误，操作下面的命令
# 还需要更新包：openssl与nss，测试使用CentOS6.8的openssl与nss包即可，其中nss有部分依赖，下面是简单整理，具体情况按实操为准
# 只更新openssl不好用，更新了nss后问题解决，但是并没有尝试只更新nss
wget [--no-check-certificate] https://vault.centos.org/6.8/os/x86_64/Packages/openssl-1.0.1e-48.el6.x86_64.rpm
rpm -Uvh openssl-1.0.1e-48.el6.x86_64.rpm
wget [--no-check-certificate] https://vault.centos.org/6.8/os/x86_64/Packages/nss-3.21.0-8.el6.x86_64.rpm
rpm -Uvh nss-3.21.0-8.el6.x86_64.rpm

# rpm依赖
wget [--no-check-certificate] https://vault.centos.org/6.8/os/x86_64/Packages/nss-3.21.0-8.el6.x86_64.rpm
wget [--no-check-certificate] https://vault.centos.org/6.8/os/x86_64/Packages/nspr-4.11.0-1.el6.x86_64.rpm
wget [--no-check-certificate] https://vault.centos.org/6.8/os/x86_64/Packages/nss-util-3.21.0-2.el6.x86_64.rpm
wget [--no-check-certificate] https://vault.centos.org/6.8/os/x86_64/Packages/nss-softokn-freebl-3.14.3-23.el6_7.x86_64.rpm
wget [--no-check-certificate] https://vault.centos.org/6.8/os/x86_64/Packages/nss-softokn-3.14.3-23.el6_7.x86_64.rpm
wget [--no-check-certificate] https://vault.centos.org/6.8/os/x86_64/Packages/nss-sysinit-3.21.0-8.el6.x86_64.rpm
wget [--no-check-certificate] https://vault.centos.org/6.8/os/x86_64/Packages/nss-tools-3.21.0-8.el6.x86_64.rpm

rpm -Uvh nspr-4.11.0-1.el6.x86_64.rpm
rpm -Uvh nss-util-3.21.0-2.el6.x86_64.rpm
rpm -Uvh nss-softokn-freebl-3.14.3-23.el6_7.x86_64.rpm
rpm -Uvh nss-softokn-3.14.3-23.el6_7.x86_64.rpm
rpm -Uvh nss-3.21.0-8.el6.x86_64.rpm nss-sysinit-3.21.0-8.el6.x86_64.rpm nss-tools-3.21.0-8.el6.x86_64.rpm
```

## 其他信息

[https://thycotic.force.com/centrifysupport/Article/KB-11461-Centrify-Yum-repo-fails-with-Errno-14-problem-making-ssl-connection/](https://thycotic.force.com/centrifysupport/Article/KB-11461-Centrify-Yum-repo-fails-with-Errno-14-problem-making-ssl-connection/)

KB-11461: Centrify Yum repo fails with [Errno 14] problem making ssl connection  
Product:Authentication Service ,  Published:  
2 October,21 at 04:34 AM

Rating:  
Problem:

Centrify Yum repo is failing with the following error:

[Errno 14] problem making ssl connection

Cause:  
On RHEL based systems (6.7 or older) when the above error is seen, it is caused by support for TLS 1.0 and 1.1 being deprecated for SSL

Resolution:  
To force SSL to start using TLS v1.2, the following packages plus any of dependencies must be updated to the latest:

- yum
- curl
- openssl
- nss

From command prompt as root or root equivalent user run the following commands:

1) yum-config-manager --disable centrify.repo
2) yum clean all
3) yum update yum
4) yum update curl
5) yum update openssl
6) yum update nss
7) yum-config-manager --enable centrify.repo

Note:  
For more information on the deprecated TLS 1.0 and 1.1 support, please see below link. (provided as a courtesy)  
[https://jfrog.com/knowledge-base/why-am-i-failing-to-work-with-jfrog-saas-service-with-tls-1-0-1-1/](https://jfrog.com/knowledge-base/why-am-i-failing-to-work-with-jfrog-saas-service-with-tls-1-0-1-1/)

For more information on using Centrify Yum Repo:  
[https://www.centrify.com/support/customer-support-portal/repos/](https://www.centrify.com/support/customer-support-portal/repos/)
