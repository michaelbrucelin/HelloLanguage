# 练习脚本：等腰三角形

#!/bin/bash

read -p "Please input a num: " num
if [[ ${num} =~ [^0-9] ]]; then
    echo "input error"
else
    for i in $(seq 1 ${num}); do
        l=$[${i}*2-1]
        for j in $(seq 1 $[${num}-${i}]); do
            echo -ne " "
        done
        for m in $(seq 1 ${l}); do
            color=$[$[RANDOM%7]+31]
            echo -ne "\033[1;${color};5m*\033[0m"
        done
        echo
    done
fi

# sh demo.sh
