#!/bin/bash

# 这里面实现了一个模板，就是当执行ping时，自动创建一个新的screen窗口，在这个窗口中执行ping
# 解决的问题是，工作场景下，同事需要远程服务器执行长时间运行sipp命令，这就导致有时候sipp执行了一半，断网导致sipp进程中断了
# yum install screen

PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin:/root/bin
export PATH
LANG=C

function usage() {
    echo "Usage: $0 --name <name> {ping args}"  # 执行ping命令，这里只接受 -I, -i, -c 以及 host|ip
    echo "Usage: $0 --list [match]"             # 列出当前的窗口
    echo "Usage: $0 --remote <name>"            # 连接指定的窗口
    exit 1;
}

parameters=$(getopt -o I:i:c: -l name:,list::,remote: -n "$0" -- "$@")
[ $? != 0 ] && usage 

or_op=$(echo "$parameters" | grep -Eo '\-\-name|\-\-list' | wc -l)
[ "$or_op" -gt 1 ] && { echo "--name and --list cannot be exist together"; usage; }
or_op=$(echo "$parameters" | grep -Eo '\-\-name|\-\-remote' | wc -l)
[ "$or_op" -gt 1 ] && { echo "--name and --remote cannot be exist together"; usage; }
or_op=$(echo "$parameters" | grep -Eo '\-\-list|\-\-remote' | wc -l)
[ "$or_op" -gt 1 ] && { echo "--list and --remote cannot be exist together"; usage; }

eval set -- "${parameters}"
while true ; do
    case "$1" in
        --list)
            case "$2" in
                "") list=' '; shift 2 ;;
                *)  list=$2;  shift 2 ;;
            esac ;;
        --remote) remote=$2;  shift 2 ;;
        --name)   name=$2;    shift 2 ;;
        -I)       I=$2;       shift 2 ;;
        -i)       i=$2;       shift 2 ;;
        -c)       c=$2;       shift 2 ;;
        --) shift; break ;;
        *) usage ;;
    esac
done

if [ -n "${list}" ]; then
    if [ "${list}" == " " ]; then
        screen -list | grep -v '/var/run/screen/'
    else
        screen -list | grep -v '/var/run/screen/' | grep "${list}"
    fi
    exit 0
fi

if [ -n "${remote}" ]; then
    screen -r "${remote}"
    exit 0
fi

if [ -z "${name}" ] || [ -z "${I}" ] || [ -z "${i}" ] || [ -z "${c}" ] || [ $# -gt 1 ]; then
    usage
fi

if ! screen -list | grep -q "${name}"; then
    screen -S "${name}" bash -c "ping $1 -I ${I} -i ${i} -c ${c}"
else
    echo "a remote window with the same name already exists"
    usage
fi

# if [ -n "${list}" ]; then echo "\$list is: ${list}"; else echo "\$list is not exists"; fi
# if [ -n "${remote}" ]; then echo "\$remote is: ${remote}"; else echo "\$remote is not exists"; fi
# if [ -n "${name}" ]; then echo "\$name is: ${name}"; else echo "\$name is not exists"; fi
# if [ -n "${I}" ]; then echo "\$I is: ${I}"; else echo "\$I is not exists"; fi
# if [ -n "${i}" ]; then echo "\$i is: ${i}"; else echo "\$i is not exists"; fi
# if [ -n "${c}" ]; then echo "\$c is: ${c}"; else echo "\$c is not exists"; fi
# if [ -n "${1}" ]; then echo "\$1 is: ${1}"; else echo "\$1 is not exists"; fi
# if [ -n "${2}" ]; then echo "\$2 is: ${2}"; else echo "\$2 is not exists"; fi
# if [ -n "${3}" ]; then echo "\$3 is: ${3}"; else echo "\$3 is not exists"; fi
# echo "the count of parameters is $#"
