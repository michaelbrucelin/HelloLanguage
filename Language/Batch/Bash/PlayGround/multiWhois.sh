#!/bin/bash

# 批量查询whois

PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin:/root/bin
export PATH

LANG=C

domains=$(cat $1)
i=1
for domain in ${domains}
do
    echo "====================domain"${i}":"${domain}".===================="
    whois ${domain} | head -n 20
    echo -e "\n\n\n"
    i=$[${i} + 1]
    sleep 1s
done
