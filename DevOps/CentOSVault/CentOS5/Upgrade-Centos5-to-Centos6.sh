# 官方并不支持直接将CentOS5升级到CentOS6，但是可以通过以下方式实现，没有测试，这里只是记录
# 链接：https://gist.github.com/jbuchbinder/8672738

# Build the CentOS 6 release package for earlier RPM database

yum install -y rpm-build
wget -c http://vault.centos.org/6.5/os/Source/SPackages/centos-release-6-5.el6.centos.11.1.src.rpm
rpm2cpio centos-release-6-5.el6.centos.11.1.src.rpm | cpio -idmv
mv centos-release*.tar.gz /usr/src/redhat/SOURCES
rpmbuild -bb centos-release.spec

# Install hash support (to unbreak yum)
yum install -y python-hashlib

# Remove things that break stuff
rpm -e kudzu
rpm -e cadaver
rpm -e ipsec-tools
rpm -e rpm -e nss_ldap.i386 nss_ldap.x86_64

# Fix RPM dependencies
wget -c  http://mirror.centos.org/centos/6/os/x86_64/Packages/xz-4.999.9-0.3.beta.20091007git.el6.x86_64.rpm \
         http://mirror.centos.org/centos/6/os/x86_64/Packages/xz-libs-4.999.9-0.3.beta.20091007git.el6.x86_64.rpm
rpm -Uvh xz-*

# Fix cpio
wget -c http://vault.centos.org/6.5/os/Source/SPackages/cpio-2.10-11.el6_3.src.rpm
rpm2cpio cpio-2.10-11.el6_3.src.rpm | cpio -idmv
mv cpio*.patch cpio.1 cpio-2.10.tar.bz2 /usr/src/redhat/SOURCES/
rpm -Uvh http://vault.centos.org/5.9/os/x86_64/CentOS/autoconf-2.59-12.noarch.rpm \
         http://vault.centos.org/5.9/os/x86_64/CentOS/imake-1.0.2-3.x86_64.rpm \
         http://vault.centos.org/5.9/os/x86_64/CentOS/texinfo-4.8-14.el5.x86_64.rpm \
         http://vault.centos.org/5.9/os/x86_64/CentOS/automake-1.9.6-2.3.el5.noarch.rpm
# Patch to force reconfiguration
perl -pi -e 's/autoheader/autoreconf\; autoheader/g;' cpio.spec         
rpmbuild -bb cpio.spec
rpm -Uvh /usr/src/redhat/RPMS/x86_64/cpio-2.10-11.el6.x86_64.rpm

# Fix glibc dependencies
wget -c http://mirror.centos.org/centos/6/os/x86_64/Packages/glibc-2.12-1.132.el6.x86_64.rpm \
        http://mirror.centos.org/centos/6/os/x86_64/Packages/glibc-{common,devel,static,utils}-2.12-1.132.el6.x86_64.rpm \
        http://mirror.centos.org/centos/6/os/x86_64/Packages/binutils-2.20.51.0.2-5.36.el6.x86_64.rpm \
        http://mirror.centos.org/centos/6/os/x86_64/Packages/libcap-2.16-5.5.el6.x86_64.rpm \
        http://mirror.centos.org/centos/6/os/x86_64/Packages/compat-libcap1-1.10-1.x86_64.rpm
rpm -Uvh xz-* glibc-* binutils-* libcap-* compat-* --nodeps --force

# Do base upgrade
yum update -y glibc* yum* rpm* python*

# Reinstate LDAP
yum install -y nss-pam-ldapd

# Full upgrade
yum upgrade -y