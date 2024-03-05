#!/bin/bash

#
# https://gist.githubusercontent.com/drmalex07/6bcd65a0861f58b646a0/raw/8c82a6f832bea475e32eb1a45707f24c16e68974/getopt-example.sh
#
# Example using getopt (vs builtin getopts) that can also handle long options.
# Another clean example can be found at:
# http://www.bahmanm.com/blogs/command-line-options-how-to-parse-in-bash-using-getopt
#

aflag=n
bflag=n
cargument=

# Parse options. Note that options may be followed by one colon to indicate 
# they have a required argument
if ! options=$(getopt -o abc: -l along,blong,clong: -- "$@")
then
    # Error, getopt will put out a message for us
    exit 1
fi

set -- $options

while [ $# -gt 0 ]
do
    # Consume next (1st) argument
    case $1 in
    -a|--along) 
        aflag="y" ;;
    -b|--blong) 
        bflag="y" ;;
    # Options with required arguments, an additional shift is required
    -c|--clong) 
        cargument="$2" ; shift;;
    (--) 
        shift; break;;
    (-*) 
        echo "$0: error - unrecognized option $1" 1>&2; exit 1;;
    (*) 
        break;;
    esac
    # Fetch next argument as 1st
    shift
done
