#!/bin/bash

PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin:/root/bin
export PATH

LANG=C

DATEEXEC="20200823-092710" # 每次执行时更新时间
sed -i "s/DATEEXEC=\"[0-9]\{8\}-[0-9]\{6\}\" # 每次执行时更新时间/DATEEXEC=\"$(date +"%Y%m%d-%H%M%S")\" # 每次执行时更新时间/" $(echo "./$0")

LANARR=(".c" ".cpp" ".cs" ".css")
LANGET=${LANARR[$(date +%s%N) % ${#LANARR[@]}]}

echo "========${LANGET}========"

case ${LANGET} in
    .c)
        echo "C"
        ;;
    .cpp)
        echo "C++"
        ;;
    .cs)
        echo "C#"
        ;;
    *)
        echo "Others"
        ;;
esac

if [ "$1" == "-f" ]; then
    echo $1
fi

echo "A: "$(pwd)

# 切换到脚本所在目录
cd "$(cd "$(dirname "${BASH_SOURCE[0]}")" > /dev/null 2>&1 && pwd)"

echo "Z: "$(pwd)

echo "$0"
echo $(basename "$0")
