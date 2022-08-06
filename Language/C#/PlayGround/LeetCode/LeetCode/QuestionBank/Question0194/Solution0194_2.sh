#!/bin/bash

COUNT=$(head -1 file.txt | wc -w)
for ((i = 1; i <= $COUNT; i++)); do
    awk -v arg=$i '{print $arg}' file.txt | xargs
done
