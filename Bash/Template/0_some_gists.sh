# 记录localhost的公网ip，使用0时区时间做记录
echo `TZ=UTC date +'%Y%m%d-%H%M%S';curl ipinfo.io` >> /root/myselfpublicip.txt 2> /dev/null