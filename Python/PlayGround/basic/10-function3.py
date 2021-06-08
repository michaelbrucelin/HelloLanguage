# 生成器
# 类似于C#中的延时执行，同样使用yield关键字

# 1. basic
import itertools


def squares(n=10):
    for i in range(1, n+1):
        yield i**2


gen = squares()  # 这时，虽然写的是调用，但是代码并没有真的执行
for x in gen:
    print(x, end=' ')  # 这个时候（请求元素的时候）才会执行代码

# 2. 生成器表达式
# 生成器表达式与列表表达式类似，只需要把中括号改为小括号即可
gen = (x**2 for x in range(100))
gen  # <generator object <genexpr> at 0x7f0d396006d8>
# 与下面代码等价
"""
def _make_gen():
    for x in range(100):
        yield x**2
gen = _make_gen()
"""

# 3. itertools模块
# 标准库中的itertools模块是适用于大多数数据算法的生成器集合
""" 下面是几个常用的itertools函数
combinations(iterable, k)      根据iterable参数中的所有元素生成一个包含所有可能K-元祖的序列，忽略元素的顺序，也不进行替代
                               combinations_with_replacement()需要替代
permutations(iterable, k)      根据iterable参数中的所有元素按顺序生成包含所有可能K元祖的序列
groupby(iterable[, keyfunc])   根据每一个独一的key生成(key, sub-iterator)元祖
product(*iterables, repeat=1)  以元祖的形式，根据输入的可遍历对象生成笛卡尔积，与嵌套的for循环类似
"""

# import itertools
letters = ['A', 'B', 'C']
list(itertools.combinations(letters, 2))
# [('A', 'B'), ('A', 'C'), ('B', 'C')]
list(itertools.permutations(letters, 2))
# [('A', 'B'), ('A', 'C'), ('B', 'A'), ('B', 'C'), ('C', 'A'), ('C', 'B')]
list(itertools.combinations_with_replacement(letters, 2))
# [('A', 'A'), ('A', 'B'), ('A', 'C'), ('B', 'B'), ('B', 'C'), ('C', 'C')]

names = ['Alan', 'Adam', 'Wes', 'Will', 'Albert', 'Steven']
for letter, names in itertools.groupby(names, lambda x: x[0]):
    print(letter, list(names))
# A ['Alan', 'Adam']
# W ['Wes', 'Will']
# A ['Albert']
# S ['Steven']

letters = ['A', 'B', 'C']
list(itertools.product(letters, letters))
# [('A', 'A'),
#  ('A', 'B'),
#  ('A', 'C'),
#  ('B', 'A'),
#  ('B', 'B'),
#  ('B', 'C'),
#  ('C', 'A'),
#  ('C', 'B'),
#  ('C', 'C')]
