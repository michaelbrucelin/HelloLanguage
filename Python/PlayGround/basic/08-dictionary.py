# 字典
# 从python 3.7开始，遍历字典，默认就是按照字典中元素插入的顺序进行遍历，也就是字典是有顺序的，而集合是没有顺序的
# 字典的键必须是不可变的，即可哈希化的类型，即hash(key)不抛异常

# 1. 声明
import pprint
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

# 2. 操作
info = {"id": "1", "name": "micha", "age": 18}
info["name"]                    # 根据键查询值
info["gender"]                  # 访问不存在的键，会报错
info["gender"] = "boy"          # 增加键值对
info["gender"] = 1              # 更改键值对
info.setdefault("height", 168)  # 由于info中没有键"height"，所以新增键值对
info.setdefault("height", 188)  # 同样的操作，由于info中含有键"height"，这次是获取键对应的值
del info["age"]                 # 删除键值对
ret = info.pop('name')          # 删除键值对，同时返回删除的值
info.clear()                    # 清空字典

# 3. 重复的键值
# {'id': 1, 'name': 'mlin', 'age': 33}
info = {"id": 1, "name": "mlin", "age": 18, "age": 33}

# 4. 字典的update()方法
dic1 = {'a': 1, 'b': 2, 'c': 4}
dic2 = {'b': 200, 'd': 400}
dic1.update(dic2)
dic1  # {'a': 1, 'b': 200, 'c': 4, 'd': 400}

# 5. 遍历字典
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

# 6. 键排序
# import pprint
info = {"id": "1", "name": "micha", "age": 18}
pprint.pprint(info)          # {'age': 18, 'id': '1', 'name': 'micha'}
print(pprint.pformat(info))  # {'age': 18, 'id': '1', 'name': 'micha'}
