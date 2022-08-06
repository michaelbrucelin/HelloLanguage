#!/bin/bash

cat words.txt | tr ' ' '\n' | sed '/^\s*$/d' | sort | uniq -c | awk '{print $2" "$1}' | sort -nrk2
