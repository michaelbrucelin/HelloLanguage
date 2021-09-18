# 练习脚本：九九乘法表

#!/bin/bash

for i in {1..9};do
    for j in $(seq 1 ${i});do
        let m=$((${i}*${j}))
        echo -e "${i}*${j}=${m}\t\c"
    done
    echo
done

# sh demo.sh