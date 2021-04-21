#!/bin/bash

PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin:/root/bin
export PATH

LANG=C

set -u  # 或set -o nounset，遇到不存在的变量，报错并停止脚本
set -e  # 或set -o errexit，脚本只要发生错误，就终止执行脚本
set -o pipefail  # -e对管道无效，这个是保证管道中发生错误，终止执行脚本

: '

在这里写脚本，去掉注释... ...

'

set +e

: '
shell script基本框架
1、第一行#!/bin/bash声明这个script使用的shell名称；
2、整个script中，除了第一行的#!用来声明shell之外，其余的#都是注释；
3、声明主要的环境变量，主要是PATH和LANG；
4、程序内容；
5、执行结果；

shell script好的编写习惯
在script文件头处记录好：
1、script的功能；
2、script的版本信息；
3、script的作者与联络方式；
4、script的版权声明方式；
5、script的history；
script内使用比较特殊的命令，使用绝对路径的方式去执行；
script内预先声明执行需要的环境变量；
'