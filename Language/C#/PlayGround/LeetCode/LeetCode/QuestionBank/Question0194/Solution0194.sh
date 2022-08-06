#!/bin/bash

COUNT=$(head -1 file.txt | wc -w)
for ((i = 1; i <= $COUNT; i++)); do
    cut -d' ' -f$i file.txt | xargs
done
