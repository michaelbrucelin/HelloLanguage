#!/bin/bash
if [ "$1" == "" ]; then
    echo 'please specify the batch test ip.'
else
    ips=`cat $1`

    for ip in $ips
    do
        #ping -nq -W1 -i0.001 -c 100 $ip
        #ping -nq -W1 -i0.001 -c 100 $ip | xargs echo
        ping -nq -W1 -i0.001 -c 100 $ip | xargs echo | sed s/' --- .* ping statistics --- '/' '/g
    done
fi
