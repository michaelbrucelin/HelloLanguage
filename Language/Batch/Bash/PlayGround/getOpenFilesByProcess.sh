#!/bin/bash

# 监控某个进程打开的文件数，以进程freeswitch为示例

while [ true ]
do
    (date +"%Y%m%d-%H%M%S"; lsof -n | grep freeswitch | wc -l) | xargs echo >> $(echo "/root/fsFileCnt_"`date +"%Y%m%d-%H"`'.txt')
    sleep 1s
done
