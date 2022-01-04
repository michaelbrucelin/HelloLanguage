# https://docs.python.org/3/library/telnetlib.html

import getpass
import telnetlib

HOST = "10.1.1.1"
user = input("Enter your remote account: ")
password = getpass.getpass()

tn = telnetlib.Telnet(HOST)

tn.read_until(b"Username:")
tn.write(user.encode('ascii') + b"\n")
if password:
    tn.read_until(b"Password:")
    tn.write(password.encode('ascii') + b"\n")

# tn.write(b"dir\n")  # or ls
# tn.write(b"exit\n")
tn.write(b"display local-user\n")
# display local-user命令没有一次性输出所有用户，而是自动应用了类似于bash的 | less的分页功能
# 所以这里发送了10个空格（华为的文档中有screen-length与screen-width两个设置命令，测试无效）
tn.write(b" "*10)
tn.write(b"quit\n")   # or exit

print(tn.read_all().decode('ascii'))
