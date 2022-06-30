#!/bin/bash

# 批量修改文件并将原文件备份

for i in $(ls *.xml)
do
    echo $i
    mv $i $i.bak
    sed 's/old/new/' < $i.bak > $i
done
