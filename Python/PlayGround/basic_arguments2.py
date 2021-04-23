#!/usr/bin/python

import sys
import getopt


def main(argv):
    inputfile = ''
    outputfile = ''
    try:
        opts, args = getopt.getopt(argv, "hi:o:", ["ifile=", "ofile="])
    except getopt.GetoptError:
        print('basic_arguments2.py -i <inputfile> -o <outputfile>')
        sys.exit(2)
    for opt, arg in opts:
        if opt == '-h':
            print('basic_arguments2.py -i <inputfile> -o <outputfile>')
            sys.exit()
        elif opt in ("-i", "--ifile"):
            inputfile = arg
        elif opt in ("-o", "--ofile"):
            outputfile = arg
    print('Input file is "', inputfile)
    print('Output file is "', outputfile)


if __name__ == "__main__":
    main(sys.argv[1:])

'''
$ python basic_arguments2.py -h
usage: basic_arguments2.py -i <inputfile> -o <outputfile>

$ python basic_arguments2.py -i BMP -o
usage: basic_arguments2.py -i <inputfile> -o <outputfile>

$ python basic_arguments2.py -i inputfile
Input file is " inputfile
Output file is "
'''
