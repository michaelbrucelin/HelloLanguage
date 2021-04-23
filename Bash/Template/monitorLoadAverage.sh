#!/bin/bash

# 网上找的他人写好的监控Linux负载平均值的脚本
# https://www.christophe-casalegno.com/how-to-automatically-take-an-action-if-the-load-average-is-too-high/

tsleep=2  # time to wait before 2 checks
llimit=8  # load limit before action
alert=monitor@christophe-casalegno.com  #put your monitor alert email here
host=`hostname -f`

load=`cat /proc/loadavg | awk {'print $1'} | cut -d "." -f1`   # The load average now
sleep $tsleep
load2=`cat /proc/loadavg | awk {'print $1'} | cut -d "." -f1`  # The load average after tsleep

if test "$load" -ge $llimit; then
    if test "$load2" -ge $load; then
        date=`date`
        echo "The Load Average has reached $load1 and $load2 on $host" | mail -s "$host : High Load Average Alert" $alert
        echo "$date : The Load Average has reached $load1 and $load2 on $host" >> /var/log/loadavg.log
    else
        echo "ok" 1>&2
    fi
else
    sleep 1
fi