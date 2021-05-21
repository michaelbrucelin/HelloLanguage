# 字典与集合
# 从python 3.7开始，遍历字典，默认就是按照字典中元素插入的顺序进行遍历，也就是字典是有顺序的，而集合是没有顺序的

# 1. 声明
dic1 = {
    "jen": "python",
    "sarah": "c",
    "edward": "ruby",
    "phil": "python",
    "erin": "csharp",
}

dic2 = {}
dic2["jen"] = "python"
dic2["sarah"] = "c"
dic2["edward"] = "ruby"

set0 = set()
set0 = {"C", "C++", "C#", "Python", "SQL", "JavaScript", "R", "Go"}
set1 = set([1, 2, 3])           # set(列表)是集合，可以看做没有值的字典
set2 = set([1, 1, 2, 2, 3, 3])  # 集合中没有重复值，可以使用集合给列表去重复

# 2. 操作
info = {"id": "1", "name": "micha", "age": 18}
info["name"]               # 根据键查询值
info["gender"]             # 访问不存在的键，会报错
info.get("gender")         # get不存在的键返回none，或者返回指定的默认值
info.get("gender", "boy")  # 指定默认值
info["gender"] = "boy"     # 增加键值对
info["gender"] = 1         # 更改键值对
del info["age"]            # 删除键值对
info.clear()               # 清空字典

# 3. 重复的键值
# {'id': 1, 'name': 'mlin', 'age': 33}
info = {"id": 1, "name": "mlin", "age": 18, "age": 33}

# 4. 遍历字典
dic = {"jen": "python", "sarah": "c", "edward": "ruby", "phil": "python", }
dic.keys()    # dict_keys(['jen', 'sarah', 'edward', 'phil'])
dic.values()  # dict_values(['python', 'c', 'ruby', 'python'])
# dict_items([('jen', 'python'), ('sarah', 'c'), ('edward', 'ruby'), ('phil', 'python')])
dic.items()

for key in dic.keys():
    print(key)

for value in dic.values():
    print(value)

for key, value in dic.items():
    print("key=%s,value=%s" % (key, value))
