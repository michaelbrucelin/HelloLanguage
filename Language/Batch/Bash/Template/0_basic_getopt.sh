#!/bin/bash

PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin:/root/bin
export PATH
LANG=C

function usage() {
    echo "Usage: $0 ... ..."
    exit 1;
}

parameters=$(getopt -o ab:c:: -l longa,longb:,longc:: -n "$0" -- "$@")
[ $? != 0 ] && usage                            # [ $? != 0 ] && exit 1
eval set -- "${parameters}"                     # 将$parameters设置为位置参数
while true ; do                                 # 循环解析位置参数
    case "$1" in
        -a|--longa) arga='y'; shift ;;          # 不带参数的选项-a或--longa
        -b|--longb) argb=$2;  shift 2 ;;        #   带参数的选项-b或--longb
        -c|--longc)                             # 参数可选的选项-c或--longc
            case "$2" in 
                "") argc='not set'; shift 2 ;;  # 没有给可选参数
                *)  argc=$2;        shift 2 ;;  #   给了可选参数
            esac ;;
        --) shift; break ;;                     # 开始解析非选项类型的参数，break后，它们都保留在$@中
        *) usage ;;                             # exit 1 ;;
    esac
done

# if [ -z "${arga}" ] || [ -z "${argb}" ] || [ -z "${argc}" ]; then
#     usage
# fi

if [ -n "${arga}" ]; then echo "\$arga is: ${arga}"; else echo "\$arga is not exists"; fi
if [ -n "${argb}" ]; then echo "\$argb is: ${argb}"; else echo "\$argb is not exists"; fi
if [ -n "${argc}" ]; then echo "\$argc is: ${argc}"; else echo "\$argc is not exists"; fi
if [ -n "${1}" ]; then echo "\$1 is: ${1}"; else echo "\$1 is not exists"; fi
if [ -n "${2}" ]; then echo "\$2 is: ${2}"; else echo "\$2 is not exists"; fi
if [ -n "${3}" ]; then echo "\$3 is: ${3}"; else echo "\$3 is not exists"; fi
if [ -n "${4}" ]; then echo "\$4 is: ${4}"; else echo "\$4 is not exists"; fi
if [ -n "${5}" ]; then echo "\$5 is: ${5}"; else echo "\$5 is not exists"; fi
if [ -n "${6}" ]; then echo "\$6 is: ${6}"; else echo "\$6 is not exists"; fi
if [ -n "${7}" ]; then echo "\$7 is: ${7}"; else echo "\$7 is not exists"; fi
if [ -n "${8}" ]; then echo "\$8 is: ${8}"; else echo "\$8 is not exists"; fi
if [ -n "${9}" ]; then echo "\$9 is: ${9}"; else echo "\$9 is not exists"; fi
echo "the count of parameters is $#"


# test
