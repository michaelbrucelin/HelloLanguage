#!/bin/bash

PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin:/root/bin
export PATH
LANG=C

function usage() {
    echo "Usage: $0 ... ..."
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

# if [ -z "${I}" ] || [ -z "${i}" ] || [ -z "${c}" ] || [ -z "${l}" ] || [ -z "${r}" ]; then
#     usage
# fi

if [ -n "${I}" ]; then echo "\$I is: ${I}"; else echo "\$I is not exists"; fi
if [ -n "${i}" ]; then echo "\$i is: ${i}"; else echo "\$i is not exists"; fi
if [ -n "${c}" ]; then echo "\$c is: ${c}"; else echo "\$c is not exists"; fi
if [ -n "${l}" ]; then echo "\$l is: ${l}"; else echo "\$l is not exists"; fi
if [ -n "${r}" ]; then echo "\$r is: ${r}"; else echo "\$r is not exists"; fi
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
# 这种使用方法命名的参数必须全部放在非命名参数的前面，参数的数量统计的是非命名参数的数量
# ./test.sh -I eth0 -i 1 -l 100 -r remote 100 200
# > $I is: eth0
# > $i is: 1
# > $c is not exists
# > $l is: list
# > $r is not exists
# > $1 is: 100
# > $2 is: -r
# > $3 is: remote
# > $4 is: 100
# > $5 is: 200
# > $6 is not exists
# > $7 is not exists
# > $8 is not exists
# > $9 is not exists
# > the count of parameters is 5
# 
# -i参数没有给值，直接报错
# ./test.sh -I eth0 -i   
# > Usage: ./test.sh ... ...
