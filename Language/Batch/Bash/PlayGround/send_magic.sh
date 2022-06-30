#!/usr/bin/env bash

# 发送魔术包实现远程开机
# 测试并不好用，不确认哪些细节每处理对，后来发现有现成的命令去做这个，就没有去深究。

mac_address=$1
# Strip colons from the MAC address
mac_address=$(echo $mac_address | sed 's/[ :-]// g')

broadcast=$2
port=50000
nc_args="-w1 -u"

if [[ $OSTYPE == darwin* ]]; then
    nc_args="$params -c"
fi

# Magic packets consist of 12*`f` followed by 16 repetitions of the MAC address
magic_packet=$(
    printf 'f%.0s' {1..12}
    printf "$mac_address%.0s" {1..16}
)
# ... and they need to be hex-escaped
magic_packet=$(
    echo $magic_packet | sed -e 's/../\\x&/g'
)

echo -e $magic_packet | nc $nc_args $broadcast $port
