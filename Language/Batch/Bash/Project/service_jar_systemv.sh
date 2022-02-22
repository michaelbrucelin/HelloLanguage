#!/bin/sh

# 将jar包部署为Linux服务，并保证服务异常挂掉后会自动重启，适用于CentOS5以及更早的CentOS操作系统。
# 将下面一行添加到/etc/inittab文件中，可以实现服务异常挂掉后自动重启（没有测试）。
# service_id:2345:respawn:/bin/bash /etc/init.d/service_name start

# chkconfig: 35 99 00

PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin:/root/bin
export PATH

LANG=C

dir="/etc/jar-service"
cmd="/usr/bin/java -jar $dir/service_name.jar"

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
        echo "service $name has already started."
    else
        echo "starting service $name... ..."
        cd "$dir"
        $cmd >>"$stdout_log" 2>>"$stderr_log" &

        echo $! >"$pid_file"
        if ! is_running; then
            echo "service $name unable to start, see $stdout_log and $stderr_log"
            exit 1
        fi
    fi
}

stop() {
    if is_running; then
        echo -n "stopping service $name... ..."
        kill $(get_pid)
        # for i in 1 2 3 4 5 6 7 8 9 10
        for i in $(seq 10); do
            if ! is_running; then
                break
            fi

            echo -n "."
            sleep 1
        done
        echo

        if is_running; then
            echo "service $name not stopped; may still be shutting down or shutdown may have failed."
            exit 1
        else
            echo "service $name has already stopped."
            if [ -f "$pid_file" ]; then
                rm "$pid_file"
            fi
        fi
    else
        echo "service $name is not running."
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
        echo "service $name unable to stop, will not attempt to start"
        exit 1
    fi
    start
    ;;
status)
    if is_running; then
        echo "service $name is running."
    else
        echo "service $name is stopped."
        exit 1
    fi
    ;;
*)
    echo "Usage: $0 {start|stop|restart|status}"
    exit 1
    ;;
esac

exit $?
