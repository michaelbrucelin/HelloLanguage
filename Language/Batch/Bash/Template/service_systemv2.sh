#!/bin/sh

# 模板来自: https://fedoraproject.org/wiki/EPEL:SysVInitScripts

# <daemonname> <summary>
# chkconfig:   <default runlevel(s)> <start> <stop>
# description: <description, split multiple lines with a backslash>

### BEGIN INIT INFO
# Provides:          此行列出了此服务提供的所有引导工具。其它服务可以在它们的#Required-Start: 和#Required-Stop: 行中引用这些引导工具。
# Required-Start:    此行列出了在此服务启动期间必须可用的任何引导工具。
# Required-Stop:     此行列出了在关闭此服务之前不应停止的任何引导工具。
# Should-Start:      此行列出了所有设施，如果存在，这些设施应该在此服务启动期间可用。目的是允许“可选”依赖关系，如果设施不可用，这些依赖关系不会导致服务失败。
# Should-Stop:       此行列出了所有设施，如果存在，则仅应在关闭此服务后停止。目的是允许“可选”依赖关系，如果设施不可用，这些依赖关系不会导致服务失败。
# Default-Start:     2 3 4 5，此行列出了默认启用服务的运行级别。与 Chkconfig 标头不同，这些运行级别以空格分隔。
# Default-Stop:      0 1 6，此行列出了默认情况下不会为其启动服务的运行级别。这些运行级别以空格分隔，并且必须包含 #Default-Start: 行中未使用的所有数字运行级别。
# Short-Description: 此行提供了对 init 脚本操作的简要总结。这不得超过一个 80 个字符的文本行。
# Description:       此行提供了对 initscript 操作的更完整描述。 它可以跨越多行，其中每个续行必须以“#”开头，后跟制表符或“#”，后跟至少两个空格字符。 多行描述由不符合此条件的第一行终止。
### END INIT INFO

# Source function library.
. /etc/rc.d/init.d/functions

exec="/path/to/<daemonname>"
prog="<service name>"
config="<path to major config file>"

[ -e /etc/sysconfig/$prog ] && . /etc/sysconfig/$prog

lockfile=/var/lock/subsys/$prog

start() {
    [ -x $exec ] || exit 5
    [ -f $config ] || exit 6
    echo -n $"Starting $prog: "
    # if not running, start it up here, usually something like "daemon $exec"
    retval=$?
    echo
    [ $retval -eq 0 ] && touch $lockfile
    return $retval
}

stop() {
    echo -n $"Stopping $prog: "
    # stop it here, often "killproc $prog"
    retval=$?
    echo
    [ $retval -eq 0 ] && rm -f $lockfile
    return $retval
}

restart() {
    stop
    start
}

reload() {
    restart
}

force_reload() {
    restart
}

rh_status() {
    # run checks to determine if the service is running or use generic status
    status $prog
}

rh_status_q() {
    rh_status >/dev/null 2>&1
}

case "$1" in
start)
    rh_status_q && exit 0
    $1
    ;;
stop)
    rh_status_q || exit 0
    $1
    ;;
restart)
    $1
    ;;
reload)
    rh_status_q || exit 7
    $1
    ;;
force-reload)
    force_reload
    ;;
status)
    rh_status
    ;;
condrestart | try-restart)
    rh_status_q || exit 0
    restart
    ;;
*)
    echo $"Usage: $0 {start|stop|status|restart|condrestart|try-restart|reload|force-reload}"
    exit 2
    ;;
esac
exit $?
