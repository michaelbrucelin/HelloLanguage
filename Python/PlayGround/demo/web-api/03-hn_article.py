import requests
import json

# 执行API调用并存储响应
url = 'https://hacker-news.firebaseio.com/v0/item/19155826.json'
r = requests.get(url)
print(f"Status code: {r.status_code}")

# 探索数据的结构
response_dict = r.json()
readable_file = 'readable_hn_data.json'
with open(readable_file) as f:
    json.dump(response_dict, f, indent=4)
