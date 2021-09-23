"""
使用Linux下的whois包收集ipv4的信息，这里仅收集“运营商”信息。
whois XXX.XXX.XXX.XXX | grep descr | sed 's/descr: *//g' | sort | uniq | sed ':a;N;$!ba;s/\n/ | /g'
whois XXX.XXX.XXX.XXX | grep -Ei 'inetnum|netrange' | sed -E 's/(inetnum|netrange): *//gI'
"""

import ipaddress

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
    return int(ipaddress.IPv4Address(addr))


def int2ip(addr):
    return str(ipaddress.IPv4Address(addr))


def get_ipv4_not_reserved():
    int_start, int_end = 0, 2**32-1
    ipv4_reserved_int = [(ip2int(a), ip2int(z)) for a, z in ipv4_reserved]
    li_tmp = [(a-1, z+1) for a, z in ipv4_reserved_int]
    li_tmp = [i for j in li_tmp for i in j]
    li_tmp.insert(0, int_start)
    li_tmp.append(int_end)
    li_tmp = list(zip(li_tmp[0::2], li_tmp[1::2]))
    ipv4_not_reserved_int = [(a, z) for a, z in li_tmp if a <= z]
    # ipv4_not_reserved = [(int2ip(a), int2ip(z)) for a, z in ipv4_not_reserved_int]
    # for a, z in ipv4_not_reserved:
    #    print(f"({a}, {z})")
    return ipv4_not_reserved_int


if __name__ == '__main__':
    cnt = 0
    result = {}
    ipv4_not_reserved = get_ipv4_not_reserved()
    for a, z in ipv4_not_reserved:
        pass
    pass
