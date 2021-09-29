#!/usr/bin/python3

import os, cgi, cgitb
import re, ipaddress, json

# print('Content-Type: text/plain')
print('Content-Type: application/json')
print('')

form=cgi.FieldStorage()
ip_str = form.getvalue('ip')
ips = set(ip_str.split(','))

rere = re.compile(r'descr:\s*(.*)\n', re.I)
result = {}
for ip in ips:
    try:
        ipaddr = ipaddress.ip_address(ip)

        cmd = f'whois {ip} | grep descr'
        rows = os.popen(cmd).readlines()
        rows = list(set([rere.search(s).group(1) for s in rows]))
        result[ip] = rows
    except ValueError:
        result[ip] = f'ip address is invalid: {ip}.'
    except:
        result[ip] = 'Usage: http://ipwhois.org?ip=8.8.8.8'

# print(json.dumps(result))  # 供程序调用
print(json.dumps(result, sort_keys=True, indent=4, separators=(', ', ': ')))
