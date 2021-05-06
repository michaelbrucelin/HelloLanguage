# json

# 1. 将列表写入json
import json
numbers = [2, 3, 5, 7, 11, 13, 17, 19]
filename = '14-numbers.json'
with open(filename, 'w') as f:  # 将数据写入json
    json.dump(numbers, f)

with open(filename) as f:
    numbers2 = json.load(f)  # 从json中读取数据
print(numbers2)

# 2. 将字典写入列表
langs = {'C': 1972, 'SQL': 1978, 'C++': 1980, 'MATLAB': 1984,
         'Python': 1991, 'JavaScript': 1995, 'C#': 2001, 'Go': 2009}
filename = '14-langs.json'
with open(filename, 'w') as f:
    json.dump(langs, f)

with open(filename) as f:
    langs2 = json.load(f)  # 从json中读取数据
print(langs)
