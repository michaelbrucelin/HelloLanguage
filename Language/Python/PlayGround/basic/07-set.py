# 集合
# 集合的键（值）必须是不可变的，即可哈希化的类型，即hash(key)不抛异常

# 1. 声明
set0 = set()
set0 = {"C", "C++", "C#", "Python", "SQL", "JavaScript", "R", "Go"}
set1 = set([1, 2, 3])           # set(列表)是集合，可以看做没有值的字典
set2 = set([1, 1, 2, 2, 3, 3])  # 集合中没有重复值，可以使用集合给列表去重复

# 2. 一个集合的一些操作
set0 = {1, 2, 3, 4, 5}
set0.add(6)     # {1, 2, 3, 4, 5, 6}
set0.remove(4)  # {1, 2, 3, 5, 6}
set0.pop(3)     # 1  {2, 3, 5, 6}
set0.clear()    # set()

# 3. 两个集合的一些操作
a = {1, 2, 3, 4, 5}
b = {3, 4, 5, 6, 7}

a.union(b)                        # a|b   a与b的并集
a.update(b)                       # a|=b  将a设置为a与b的并集
a.intersection(b)                 # a&b   a与b的交集
a.intersection_update(b)          # a&=b  将a设置为a与b的交集
a.difference(b)                   # a-b   a与b的差集
a.difference_update(b)            # a-=b  将a设置为a与b的差集
a.symmetric_difference(b)         # a^b   (a|b)-(a&b)
a.symmetric_difference_update(b)  # a^=b  将a设置为(a|b)-(a&b)
a.issubset(b)                     # a是否是b的子集
a.issuperset(b)                   # a是否是b的超集
a.isdisjoint(b)                   # a与b的交集是否为空

# 4. 最佳实践
# 对于大型集合，第二种操作方式效率更高
a = set()
b = set()
a |= b        # 对于大型集合，这样操作效率低
c = a.copy()  # 对于大型集合，这样操作效率更高
c |= b

# 5. 使用map()创建集合
strings = ['a', 'as', 'bat', 'car', 'dove', 'python']
set(map(len, strings))  # {1, 2, 3, 4, 6}
