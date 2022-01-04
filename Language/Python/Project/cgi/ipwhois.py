#!/usr/bin/python3

import os, cgi, cgitb
import re, ipaddress, json

# print('Content-Type: text/plain')
print('Content-Type: application/json')
print('')

form=cgi.FieldStorage()
try:
    ip = form.getvalue('ip')
    ipaddr = ipaddress.ip_address(ip)

    rere = re.compile(r'descr:\s*(.*)\n', re.I)
    cmd = f'whois {ip} | grep descr'
    result = os.popen(cmd).readlines()
    result = [rere.search(s).group(1) for s in result]
    print(json.dumps(result))
except ValueError:
    print(f'ip address is invalid: {ip}.')
except:
    print('Usage: http://ipwhois.org?ip=8.8.8.8')
