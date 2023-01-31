#!/bin/bash

# 自动连接VPN

ping -c 1 -w 1 172.16.1.2 &>/dev/null && result=0 || result=1

while [ "$result" == 1 ]; do
    killall pppd &>/dev/null
    pppd call lala
    sleep 10
    ifconfig | grep 'ppp0' &>/dev/null && isppp0=0 || isppp0=1
    while [ "$isppp0" == 1 ]; do
        killall pppd &>/dev/null
        pppd call lala
        sleep 10
        ifconfig | grep 'ppp0' &>/dev/null && isppp0=0 || isppp0=1
    done

    route add -net 172.16.1.0 netmask 255.255.255.0 dev ppp0

    ping -c 1 -w 1 172.16.1.2 &>/dev/null && result=0 || result=1
done
