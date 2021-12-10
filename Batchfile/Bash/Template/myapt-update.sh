#!/bin/bash

PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin:/root/bin
export PATH

LANG=C
set -e

function usage() {
    echo "Usage: $0"
    echo "       $0 -y"
    exit 1;
}

command -v apt-file >/dev/null 2>&1 || {
    echo -e "\033[32mapt-get update\033[0m"
    apt-get update
    echo -e "\033[32mapt-get install apt-file\033[0m"
    apt-get install apt-file
    echo -e "\n"
}

if [ "$#" -eq "0" ]; then
    cur_uname=$(uname -a)

    echo -e "\033[32mapt-get update\033[0m"
    apt-get update

    echo -e "\n\033[32mapt-file update\033[0m"
    apt-file update

    echo -e "\n\033[32mapt-get dist-upgrade\033[0m"
    apt-get dist-upgrade

    echo -e "\n\033[32mapt-get autoremove\033[0m"
    apt-get autoremove

    echo -e "\n\033[32mapt-get clean && apt-get autoclean\033[0m"
    apt-get clean && apt-get autoclean

    echo -e "\n"
    echo -e "\033[32mA: ${cur_uname}\033[0m"
    echo -e "\033[32mZ: $(uname -a)\033[0m"
elif [ "$#" -eq "1" -a "$1" == "-y" ]; then
    cur_uname=$(uname -a)

    echo -e "\033[32mapt-get update\033[0m"
    apt-get update

    echo -e "\n\033[32mapt-file update\033[0m"
    apt-file update

    echo -e "\n\033[32mapt-get dist-upgrade -y\033[0m"
    apt-get dist-upgrade -y

    echo -e "\n\033[32mapt-get autoremove -y\033[0m"
    apt-get autoremove -y

    echo -e "\n\033[32mapt-get autoclean && apt-get clean\033[0m"
    apt-get autoclean && apt-get clean

    echo -e "\n"
    echo -e "\033[32mA: ${cur_uname}\033[0m"
    echo -e "\033[32mZ: $(uname -a)\033[0m"
else
    usage;
fi

set +e