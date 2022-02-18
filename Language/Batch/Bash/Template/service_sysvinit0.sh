#!/bin/sh

# 部署服务的模板，自己编写的，可以按照自己的需要修改。

# chkconfig: 35 99 00
ms:2345:respawn:/bin/sh /usr/bin/service_name

PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin:/root/bin
export PATH

LANG=C

dir=""
cmd=""
user=""

name=$(basename $0)
pid_file="/var/run/$name.pid"
stdout_log="/var/log/$name.log"
stderr_log="/var/log/$name.err"

get_pid() {
    cat "$pid_file"
}

is_running() {
    [ -f "$pid_file" ] && ps -p $(get_pid) >/dev/null 2>&1
}

start() {
    if is_running; then
        echo "Already started"
    else
        echo "Starting $name"
        cd "$dir"
        if [ -z "$user" ]; then
            sudo $cmd >>"$stdout_log" 2>>"$stderr_log" &
        else
            sudo -u "$user" $cmd >>"$stdout_log" 2>>"$stderr_log" &
        fi
        echo $! >"$pid_file"
        if ! is_running; then
            echo "Unable to start, see $stdout_log and $stderr_log"
            exit 1
        fi
    fi
}

stop() {
    if is_running; then
        echo -n "Stopping $name.."
        kill $(get_pid)
        for i in 1 2 3 4 5 6 7 8 9 10; do # for i in `seq 10`
            if ! is_running; then
                break
            fi

            echo -n "."
            sleep 1
        done
        echo

        if is_running; then
            echo "Not stopped; may still be shutting down or shutdown may have failed"
            exit 1
        else
            echo "Stopped"
            if [ -f "$pid_file" ]; then
                rm "$pid_file"
            fi
        fi
    else
        echo "Not running"
    fi
}

case "$1" in
start)
    start
    ;;
stop)
    stop
    ;;
restart)
    stop
    if is_running; then
        echo "Unable to stop, will not attempt to start"
        exit 1
    fi
    start
    ;;
status)
    if is_running; then
        echo "service service_name is running."
    else
        echo "service service_name is stopped."
        exit 1
    fi
    ;;
*)
    echo "Usage: $0 {start|stop|restart|status}"
    exit 1
    ;;
esac

exit $?
