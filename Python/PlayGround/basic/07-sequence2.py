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

# 7. 使用zip()将两个序列配对，创建一个元组构成的列表
seq1 = ['foo', 'bar', 'baz']
seq2 = ['one', 'two', 'three']
zipped = zip(seq1, seq2)

print(list(zipped))  # [('foo', 'one'), ('bar', 'two'), ('baz', 'three')]

# 当序列长度不等时，按最短的序列来算
seq3 = [False, True]
zipped = zip(seq1, seq2, seq3)

print(list(zipped))  # [('foo', 'one', False), ('bar', 'two', True)]

# zip()经常用来遍历多个序列
for i, (a, b) in enumerate(zip(seq1, seq2)):
    print(f"{i}: {a}-{b}")
