# Python中列表、元组、字符串都是序列，有一些共同方法

# 5. 遍历序列的同时，使用当前元素的索引
some_list = ['foo', 'bar', 'baz']
# 5.1 自己构建
i = 0
for value in some_list:
    print(f"i++: {i}-{value}")
    i += 1

# 5.2 使用enumerate
for i, value in enumerate(some_list):
    print(f"enumerate: {i}-{value}")

# 6. 使用sorted()创建已排序的列表
sorted([7, 1, 2, 6, 0, 3, 2])

# 7. 使用reversed()创建倒叙的列表
list(reversed([7, 1, 2, 6, 0, 3, 2]))  # [2, 3, 0, 6, 2, 1, 7]
list(reversed(range(10)))              # [9, 8, 7, 6, 5, 4, 3, 2, 1, 0]
