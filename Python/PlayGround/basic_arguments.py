#!/usr/bin/python

import sys

print('Number of arguments:', len(sys.argv), 'arguments.')
print('Argument List:', str(sys.argv))

for i in range(0, len(sys.argv)):
    print(i, sys.argv[i])

# python test.py arg1 arg2 arg3
