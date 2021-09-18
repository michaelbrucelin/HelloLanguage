# 从配置文件中读取配置，保存到变量中
# https://stackoverflow.com/questions/16571739/parsing-variables-from-config-file-in-bash
# https://askubuntu.com/questions/743493/best-way-to-read-a-config-file-in-bash

# 核心，直接使用source，简单粗暴

# 1. 创建一个用于测试的配置文件
cat > testconfig.conf << eof
A=aaa
hello=111
B=222
C=asdf
D="dd-\${hello}-dd"
hello=12345
eof

# 2. 脚本中读取配置文件测试
'''
# vim read.sh
#!/bin/bash

iPATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin:/root/bin
export PATH

LANG=C

. /tmp/testconfig.conf

echo "A: ${A}"
echo "B: ${B}"
echo "C: ${C}"
echo "D: ${D}"
echo "hello: ${hello}"
'''

'''
# bash test.sh
A: aaa
B: 222
C: asdf
D: dd-111-dd
hello: 12345
'''
