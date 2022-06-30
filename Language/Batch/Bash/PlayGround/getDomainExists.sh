#!/bin/bash

# 查询域名是否存在

if [ "$1" == "" ]; then
    echo 'please specify the batch domains.'
else
    domains=$(cat $1)
    for domain in ${domains}
    do
        result=$(whois "${domain}" | head -n 3 | xargs echo | sed 's/]/];/g')
        # echo "${domain}"
        # echo "${result}"
        echo "${domain}"'; '"${result}" >> /root/"${1%.*}"_result.txt
    done
fi
