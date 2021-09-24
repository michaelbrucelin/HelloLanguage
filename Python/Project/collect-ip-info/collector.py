"""
使用Linux下的whois包收集ipv4的信息，这里仅收集“运营商”信息。
whois XXX.XXX.XXX.XXX 2> /dev/null | grep descr | sed 's/descr: *//g' | sort | uniq | sed ':a;N;$!ba;s/\n/ | /g'
whois XXX.XXX.XXX.XXX 2> /dev/null | grep -Ei 'inetnum|netrange' | sed -E 's/(inetnum|netrange): *//gI'

停止开发：
本意：将ipv4的whois结果缓存到本地的数据库，供本地使用
        从1.0.0.0（第一个非保留ip）开始查询，解读inetnum或者NetRange字段，使用结束ip的下一个ip继续查询，重复下去，就可以把全部ip的结果查询出来
问题：有些ip返回的inetnum或者NetRange并不准确，十分大，导致没有办法依赖于这个ip范围跳着查询，这样就只能逐个ip查询
        逐个ip查询的话，一来是太慢，二来是，即使查询回来，条目这么多，需要整理，存储的架构也复杂
        所以直接改为现用现查
问题示例：来一个典型的
# whois 5.42.192.0
... ...
inetnum:        0.0.0.0 - 255.255.255.255
netname:        IANA-BLK
descr:          The whole IPv4 address space
country:        EU # Country field is actually all countries in the world and not just EU countries
org:            ORG-IANA1-RIPE
... ...
"""

import os
import re
import ipaddress
import pandas as pd

# Reserved IP addresses from https://en.wikipedia.org/wiki/Reserved_IP_addresses
# 数据有序，且不存在可以合并的区间
ipv4_reserved = [
    ('0.0.0.0', '0.255.255.255'),
    ('10.0.0.0', '10.255.255.255'),
    ('100.64.0.0', '100.127.255.255'),
    ('127.0.0.0', '127.255.255.255'),
    ('169.254.0.0', '169.254.255.255'),
    ('172.16.0.0', '172.31.255.255'),
    ('192.0.0.0', '192.0.0.255'),
    ('192.0.2.0', '192.0.2.255'),
    ('192.88.99.0', '192.88.99.255'),
    ('192.168.0.0', '192.168.255.255'),
    ('198.18.0.0', '198.19.255.255'),
    ('198.51.100.0', '198.51.100.255'),
    ('203.0.113.0', '203.0.113.255'),
    ('224.0.0.0', '239.255.255.255'),
    # ('233.252.0.0', '233.252.0.255'),  # 这个段已经被上面的段包含了
    ('240.0.0.0', '255.255.255.254'),
    ('255.255.255.255', '255.255.255.255')
]


def ip2int(addr):
    """将ip地址转换成10进制整型"""
    return int(ipaddress.IPv4Address(addr))


def int2ip(addr):
    """将十进制整型转换成ip地址"""
    return str(ipaddress.IPv4Address(addr))


def get_ipv4_not_reserved():
    """计算公共ip 地址的合法区间，以整型的形式返回"""
    int_start, int_end = 0, 2**32-1
    ipv4_reserved_int = [(ip2int(a), ip2int(z)) for a, z in ipv4_reserved]
    li_tmp = [(a-1, z+1) for a, z in ipv4_reserved_int]
    li_tmp = [i for j in li_tmp for i in j]
    li_tmp.insert(0, int_start)
    li_tmp.append(int_end)
    li_tmp = list(zip(li_tmp[0::2], li_tmp[1::2]))
    ipv4_not_reserved = [(int2ip(a), int2ip(z)) for a, z in li_tmp if a <= z]
    for a, z in ipv4_not_reserved:
        print(f"({a}, {z})")
    return ipv4_not_reserved


def get_ipv4_info(ip_start, ip_end):
    """查询ip_start ~ ip_end之间（含两端）ip的whois信息，ip_start与ip_end均为ip地址形式，而不是整型"""
    ip_search, ip_end_int = ip_start, ip2int(ip_end)
    regex_ip = re.compile(r'((?:\d{1,3}\.){3}\d{1,3})')
    while True:
        cmd = f'whois {ip_search} 2> /dev/null | iconv -t utf-8 2> /dev/null'
        rows = os.popen(cmd).readlines()
        row_ser = pd.Series(rows)
        netrange = row_ser[row_ser.str.match(
            r'^(inetnum|netrange): *(?:\d{1,3}\.){3}\d{1,3}.*(?:\d{1,3}\.){3}\d{1,3}', case=False)].iloc[0]
        netrange = regex_ip.findall(netrange)  # 当前被查询ip所在ip段的起始和结束ip

        print(f'{ip_search}: {netrange[0]} - {netrange[1]}')

        if(ip2int(netrange[1]) >= ip_end_int):
            break
        else:
            ip_search = int2ip(ip2int(netrange[1])+1)
    else:
        print('done! done! done! done! done! done! done! done! done! done! done! done! done! done! done! done!')


if __name__ == '__main__':
    # get_ipv4_not_reserved()
    get_ipv4_info('1.0.0.0', '9.255.255.255')
    pass
