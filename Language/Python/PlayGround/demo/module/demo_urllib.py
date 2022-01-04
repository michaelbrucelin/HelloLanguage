import urllib.request

# GET
'''
response = urllib.request.urlopen("http://www.baidu.com")
print(response.read().decode("utf-8"))
'''

# POST
'''
import urllib.parse
data = bytes(urllib.parse.urlencode({"hello":"world"}), encoding="utf-8")
response = urllib.request.urlopen("http://httpbin.org/post", data=data)
print(response.read().decode("utf-8"))
'''

# timeout
'''
import urllib.error
try:
    response = urllib.request.urlopen("http://httpbin.org/get", timeout=0.001)
    print(response.read().decode("utf-8"))
except urllib.error.URLError as ex:
    print(ex)
'''

# 获取状态码
'''
response = urllib.request.urlopen("http://douban.com")
print(response.status)  #418，通常表示服务器发现你是爬虫，禁止爬虫
'''
'''
response = urllib.request.urlopen("http://baidu.com")
print(response.status)
print(response.getheaders())
'''

# 构造hrader进行请求
'''
import urllib.parse
url = "http://httpbin.org/post"
headers = {
    "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.92 Safari/537.36"
}
data = bytes(urllib.parse.urlencode({"name":"abcd"}), encoding="utf-8")
req = urllib.request.Request(url=url, data=data, headers=headers, method="POST")
rep = urllib.request.urlopen(req)
print(rep.read().decode("utf-8"))
'''

# 伪装，防止服务器发现自己的是爬虫
# 伪装前
'''
response = urllib.request.urlopen("http://douban.com")
print(response.status)  #418，通常表示服务器发现你是爬虫，禁止爬虫
'''
# 伪装后
import urllib.parse
url = "http://www.douban.com"
headers = {
    "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.92 Safari/537.36"
}
req = urllib.request.Request(url=url, headers=headers)
rep = urllib.request.urlopen(req)
print(rep.read().decode("utf-8"))