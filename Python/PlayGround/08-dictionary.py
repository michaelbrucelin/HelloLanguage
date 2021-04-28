info = {"name": "mlin", "age": 18}
print(info["name"])
# print(info["gender"])  #访问不存在的键，会报错
print(info.get("gender"))  # get不存在的键返回none，或者返回指定的默认值
print(info.get("gender", "boy"))

info["id"] = 1
print(info)
del info["age"]
print(info)
info.clear()
print(info)

info2 = {"id": 1, "name": "mlin", "age": 18}
print(info2.keys())
print(info2.values())
print(info2.items())  # 每一项都是一个元组

for key in info2.keys():
    print(key)

for value in info2.values():
    print(value)

for key, value in info2.items():
    print("key=%s,value=%s" % (key, value))
