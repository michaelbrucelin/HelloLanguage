# 配置CentOS5/6 yum源

示例中的yum源文件基于[https://vault.centos.org/](https://vault.centos.org/)制作，基本可信，这里以配置CentOS6.8的yum源为例。

```bash
cd /etc/yum.repos.d
mv CentOS-Base.repo CentOS-Base.repo.bak
wget [--no-check-certificate] https://raw.githubusercontent.com/michaelbrucelin/HelloLanguage/main/Z_Others/CentOSVault/CentOS6/CentOS-Base.repo
# curl -[k]o CentOS-Base.repo ... ...   # 没有wget的话可以使用curl命令，或者vi自己创建
sed -i 's/6.10/6.8/g' CentOS-Base.repo  # 更改yum源中的版本信息

# CentOS5
# wget https://raw.githubusercontent.com/michaelbrucelin/HelloLanguage/main/Z_Others/CentOSVault/CentOS5/CentOS-Base.repo
# sed -i 's/5.11/5.8/g' CentOS-Base.repo

# 上述操作完成后，如果执行yum提示证书错误，操作下面的命令
# 测试必须使用CentOS6.10的ca-certificates包，使用6.8的无效
wget [--no-check-certificate] https://vault.centos.org/6.10/os/x86_64/Packages/ca-certificates-2018.2.22-65.1.el6.noarch.rpm
rpm -Uvh ca-certificates-2018.2.22-65.1.el6.noarch.rpm
```

完成。
