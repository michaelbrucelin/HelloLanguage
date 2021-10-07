#!/usr/bin/python3

import os, cgi, cgitb
import re, ipaddress, json
import redis

# print('Content-Type: text/plain')
print('Content-Type: application/json')
print('')

form=cgi.FieldStorage()
ip_str = form.getvalue('ip')
ips = set([ip.strip() for ip in ip_str.split(',')])

rds = redis.StrictRedis(host='localhost', port=6379, db=0, charset='utf-8', decode_responses=True)
rere = re.compile(r'descr:\s*(.*)\n', re.I)
rere2 = re.compile(r'(?:netname|organization|organisation|orgname|org-name|organization name|organisation name)\s*:\s*(.*)\n', re.I)
result = {}
for ip in ips:
    try:
        ipaddr = ipaddress.ip_address(ip)

        if rds.llen(ip) > 0:
            result[ip] = rds.lrange(ip, 0, -1)
        else:
            cmd = f'whois {ip}'
            rows = os.popen(cmd).readlines()
            infos = list(set([rere.match(s).group(1) for s in rows if rere.match(s)]))
            if len(infos) == 0:
                infos = list(set([rere2.match(s).group(1) for s in rows if rere2.match(s)]))
            if len(infos) > 0:
                rds.rpush(ip, *infos)     # 放入缓存
                rds.expire(ip, 60*60*72)  # 72小时过期时间，或者永不过期，有另外一个脚本，每天夜里更新缓存的数据，这里先采用72小时过期时间试试
            result[ip] = infos
    except ValueError:
        result[ip] = 'ip address is invalid.'
    except:
        result[ip] = 'Usage: http://ipwhois.org?ip=8.8.8.8,8.8.4.4'

print(json.dumps(result))  # 供程序调用
# print(json.dumps(result, sort_keys=True, indent=4, separators=(', ', ': ')))
