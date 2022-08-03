#!/bin/bash

# ${QUERY_STRING}是URL携带的参数
SAVEIFS=${IFS}
IFS='=&'
paraarr=(${QUERY_STRING})
IFS=${SAVEIFS}

declare -A paradic
for ((i=0; i<${#paraarr[@]}; i+=2))
do
    paradic[${paraarr[i]}]=${paraarr[i+1]}
done


echo "content-type: text/plain"
echo
for key in ${!paradic[@]}; do
    echo ${key} ${paradic[${key}]}
done

eof
