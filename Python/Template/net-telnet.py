# https://docs.python.org/3/library/telnetlib.html

import getpass
import telnetlib

HOST = "10.1.1.1"
user = input("Enter your remote account: ")
password = getpass.getpass()

tn = telnetlib.Telnet(HOST)

tn.read_until(b"Username: ")
tn.write(user.encode('ascii') + b"\n")
if password:
    tn.read_until(b"Password: ")
    tn.write(password.encode('ascii') + b"\n")

# tn.write(b"ls\n")
# tn.write(b"exit\n")
tn.write(b"display local-user\n")
tn.write(b"exit\n")

print(tn.read_all().decode('ascii'))
