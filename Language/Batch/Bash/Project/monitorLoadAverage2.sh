############### START OF THE SCRIPT ###############

#!/bin/bash

# 网上找的他人写好的监控Linux负载平均值的脚本
# https://mithunkumr.wordpress.com/2012/10/17/shell-script-to-monitor-load-average-on-a-linux-server/

# Define Variables
CUR_TIME=`date +"%A %b %e %r"`
HOSTNAME=`hostname`

# Retrieve the load average of the past 1 minute
Load_AVG=`uptime | cut -d'l' -f2 | awk '{print $3}' | cut -d. -f1`
LOAD_CUR=`uptime | cut -d'l' -f2 | awk '{print $3 " " $4 " " $5}' | sed 's/,//'`

# Define Threshold. This value will be compared with the current
# load average. Set the value as per your wish.
LIMIT=5

# Compare the current load average with the Threshold value and
# email the server administrator if the current load average is greater.
if [ $Load_AVG -gt $LIMIT ]; then
    #Save the current running processes in a file
    /bin/ps auxf >> /root/ps_output
    
    # Save the other values in a file
    echo "Current Time :: $CUR_TIME" >> /tmp/monitload.txt
    echo "Current Load Average :: $LOAD_CUR" >> /tmp/monitload.txt
    echo "The list of current processes is attached with the email for your reference." >> /tmp/monitload.txt
    echo "Please Check... ASAP."  >> /tmp/monitload.txt
    
    # Send an email to the administrator of the server
    /usr/bin/mutt -s "ALERT!!! High 1 minute load average on '$HOSTNAME'" -a /root/ps_output youremail@youremail.com < /tmp/monitload.txt
fi

# Remove the temporary log files
/bin/rm -f /tmp/monitload.txt
/bin/rm -f /root/ps_output

############### END OF THE SCRIPT ###############