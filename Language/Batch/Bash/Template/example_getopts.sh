#!/bin/bash

#
# https://gist.githubusercontent.com/drmalex07/6bcd65a0861f58b646a0/raw/8c82a6f832bea475e32eb1a45707f24c16e68974/getopts-example.sh
#

while getopts ":da:" opt; do
    case $opt in
        d)
            echo "Entering DEBUG mode"
            ;;
        a)
            echo "Got option 'a' with argurment ${OPTARG}"
            ;;
        :)
            echo "Error: option ${OPTARG} requires an argument" 
            ;;
        ?)
            echo "Invalid option: ${OPTARG}"
            ;;
    esac
done

shift $((OPTIND-1))

echo "Remaining args are: <${@}>"
