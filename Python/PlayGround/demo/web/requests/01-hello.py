import requests

# 1. 下载一个网页
res = requests.get('https://www.baidu.com/')
type(res)                             # requests.models.Response
res.status_code                       # 200
res.status_code == requests.codes.ok  # True
len(res.text)                         # 2443
res.text[:64]
# '<!DOCTYPE html>\r\n<!--STATUS OK--><html> <head><meta http-equiv=c'
res.raise_for_status()                # 如果文件下载错误，将抛异常，如果下载成功，什么也不操作

# 2. 将下载的网页保存为本地文件
# 使用'wb'参数，即使用“写二进制”的模式打开文件，目的是保存该文本中的Unicode编码
res = requests.get('https://www.baidu.com/')
res.raise_for_status()
playFile = open('data/unicodepage.html', 'wb')
for trunk in res.iter_content(100000):  # 100000算是一个最贱实践的数值
    playFile.write(trunk)
playFile.close()
