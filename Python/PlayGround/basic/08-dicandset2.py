# 7. 从序列生成字典
key_list = list(range(5))
value_list = list(reversed(range(5)))
mapping1 = {}
for key, value in zip(key_list, value_list):
    mapping1[key] = value

mapping2 = dict(zip(range(5), reversed(range(5))))
