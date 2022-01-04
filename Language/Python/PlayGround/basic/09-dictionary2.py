# 字典

# 7. 从序列生成字典
from collections import defaultdict
key_list = list(range(5))
value_list = list(reversed(range(5)))
mapping1 = {}
for key, value in zip(key_list, value_list):
    mapping1[key] = value

mapping2 = dict(zip(range(5), reversed(range(5))))

# 8. 默认值，get()与pop()的默认值使用
# 通常情况下，会有这种代码逻辑
"""
if key in some_dict:
    value = some_dict[key]
else:
    value = default_value
    """
# 这种代码逻辑，python给了个语法糖
"""
value = some_dict.get(key, default_value)
"""

info = {"id": "1", "name": "micha", "age": 18}
info.get("gender")         # None，get不存在的键返回none，或者返回指定的默认值
info.get("gender", "boy")  # boy，指定默认值
info.pop("gender")         # pop不存在的键异常
info.pop("gender", "boy")  # boy，指定默认值

# 9. setdefault()的默认值使用
words = ['apple', 'bat', 'bar', 'atom', 'book']
# 9.1 常规写法
by_letter = {}
for word in words:
    letter = word[0]
    if letter not in by_letter:
        by_letter[letter] = [word]
    else:
        by_letter[letter].append(word)
# 9.2 使用setdefault()方法
by_letter = {}
for word in words:
    letter = word[0]
    by_letter.setdefault(letter, []).append(word)
# 9.3 使用内置的defaultdict类
# from collections import defaultdict
by_letter = defaultdict(list)  # 设置字典的默认类型或能在各位置生成默认值的函数
for word in words:
    by_letter[word[0]].append(word)
