#!/bin.bash

# 查询ip所属国家

if [ "$1" == "" ]; then
    echo 'please specify the batch test ip.'
else
    ips=`cat $1`
    for ip in $ips
    do
        echo -e $ip"\t"$(whois -n $ip @whois.apnic.net | grep country | head -n1 | awk '{print $2}')
    done
fi
