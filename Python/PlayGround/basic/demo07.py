info = {"name":"mlin", "age":18}
print(info["name"])
#print(info["gender"])  #访问不存在的键，会报错
print(info.get("gender"))  #get不存在的键返回none，或者返回指定的默认值
print(info.get("gender", "boy"))

info["id"] = 1
print(info)
del info["age"]
print(info)
info.clear()
print(info)

info2 = {"id":1, "name":"mlin", "age":18}
print(info2.keys())
print(info2.values())
print(info2.items())  #每一项都是一个元组

for key in info2.keys():
    print(key)

for value in info2.values():
    print(value)

for key,value in info2.items():
    print("key=%s,value=%s"%(key,value))

s1 = set([1, 2, 3])  #set(列表)是集合，可以看做没有值的字典
print(s1)
s2 = set([1, 1, 2, 2, 3, 3])  #集合中没有重复值，可以使用集合给列表去重复
print(s2)