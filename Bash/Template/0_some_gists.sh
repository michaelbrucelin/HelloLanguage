# 记录localhost的公网ip
echo `date -d '+12 hour' +'\%Y\%m\%d-\%H\%M\%S';curl ipinfo.io` >> /root/myselfpublicip.txt 2> /dev/null