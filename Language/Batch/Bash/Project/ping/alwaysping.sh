#!/bin/bash

while [ true ]
do
    ping -nq -i1 -c 100 $1 | xargs echo | sed s/' --- .* ping statistics --- '/' '/g >> $(echo "/root/netTestResult/$1_"`date +"%Y%m%d"`'.txt')
done
