#!/bin/bash

PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin:/root/bin
export PATH

LANG=C

function usage() {
    echo "Usage: $0 --qiandao"
    echo "       $0 --daka"
    exit 1
}

if [ "$#" -ne "1" ]; then
    usage
fi

case "$1" in
--qiandao)
    docker start mymusic
    curl -c ./cookiefile 'http://127.0.0.1:3000/login/cellphone?phone=13812345678&md5_password=675053bf6403c0a4531a65ac09717226' | jq
    curl -b ./cookiefile 'http://127.0.0.1:3000/daily_signin?type=0' | jq
    ;;
--daka)
    docker start mymusic
    lists=$(curl -b ./cookiefile 'http://127.0.0.1:3000/recommend/resource' | jq '.recommend[].id')
    IFS=' ' read -r -a listarr <<<${lists}
    count=$((400 + 1 + $RANDOM % 112)) # random 401~512，每天上限300首，这里随机播放400~512首
    declare -i i=0
    for list in "${listarr[@]}"; do
        songs=$(curl -b ./cookiefile 'http://127.0.0.1:3000/playlist/track/all?id='"${list}"'&limit='"${count}" | jq '.songs[].id')
        IFS=' ' read -r -a songarr <<<${songs}
        for song in "${songarr[@]}"; do
            echo $((++i))
            time=$((128 + 1 + $RANDOM % 128)) # random 129~256
            curl -b ./cookiefile 'http://127.0.0.1:3000/scrobble?id='"${song}"'&sourceid='"${list}"'&time='"${time}"
            echo
            sleep 1s
            [ $i -ge $count ] && break
        done
        [ $i -ge $count ] && break
    done
    ;;
*)
    usage
    ;;
esac
