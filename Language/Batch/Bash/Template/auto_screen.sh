#!/bin/bash

# 这里面实现了一个模板，就是当执行ping时，自动创建一个新的screen窗口，在这个窗口中执行ping
# 解决的问题是，工作场景下，同事需要远程服务器执行长时间运行sipp命令，这就导致有时候sipp执行了一半，断网导致sipp进程中断了
# yum install screen

PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin:/root/bin
export PATH
LANG=C

function usage() {
    echo "Usage: $0 {ping args}"       # 执行ping命令，这里之接受 -I, -i, -c 以及 host|ip
    echo "Usage: $0 -l"                # 列出当前的窗口
    echo "Usage: $0 -r <window-name>"  # 连接指定的窗口
    exit 1;
}

while getopts ":I:i:c:lr:" arg; do
    case "${arg}" in
        I)
            I=${OPTARG}
            ;;
        i)
            i=${OPTARG}
            ;;
        c)
            c=${OPTARG}
            ;;
        l)
            l="list"
            ;;
        r)
            r=${OPTARG}
            ;;
        *)
            usage
            ;;
    esac
done
shift $((OPTIND-1))
