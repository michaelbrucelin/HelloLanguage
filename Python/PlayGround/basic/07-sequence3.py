# Python中列表、元组、字符串都是序列，有一些共同方法

# 8. 压缩，使用zip()将两个序列配对，创建一个元组构成的列表
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

# 9. 解压，使用zip(*)拆包，一种魔幻用法
EC = [('A', 1), ('B', 2), ('C', 3)]
letters, digits = zip(*EC)
letters  # ('A', 'B', 'C')
digits   # (1, 2, 3)
