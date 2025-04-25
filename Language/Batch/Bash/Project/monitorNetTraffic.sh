#!/bin/bash

# 监控网卡inbound的流量，如果达到100mbts，则认为是被工具，抓包60秒

if [ -z "$1" ]; then
    echo "Usage: $0 interface"
    exit 1
fi

IFACE="$1"
THRESHOLD=$((100 * 1024 * 1024))  # 100MB/s
INTERVAL=1                        # 检测间隔秒
CAPTURE_DURATION=60               # 抓包时长秒
COOLDOWN=1                        # 抓包后等待冷却时间

# echo "start monitor: ${IFACE}, threshold: $((THRESHOLD / 1024 / 1024)) MB/s"

while true; do
    RX1=$(cat /sys/class/net/${IFACE}/statistics/rx_bytes)
    sleep ${INTERVAL}
    RX2=$(cat /sys/class/net/${IFACE}/statistics/rx_bytes)
    RATE=$((RX2 - RX1))

    # echo "[$(date)] receive rate: $((RATE / 1024 / 1024)) MB/s"

    if [ ${RATE} -ge ${THRESHOLD} ]; then
        TS=$(date +%Y%m%d%H%M%S)
        FILE="capture_${IFACE}_${TS}.pcap"
        timeout ${CAPTURE_DURATION} tcpdump -i ${IFACE} -w "${FILE}" -Z root
        sleep ${COOLDOWN}
    fi
done
