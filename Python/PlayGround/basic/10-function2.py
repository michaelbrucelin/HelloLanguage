from functools import partial
import re

# 1. 使用“函数列表”处理数据，有些像C#中的委托链
states = ['   Alabama ', 'Georgia!', 'Georgia', 'georgia',
          'FlOrIda', 'south   carolina##', 'West virginia?']


def remove_punctuation(value):
    return re.sub('[!#?]', '', value)


# 可以这样这接声明“函数列表”
clean_ops = [str.strip, remove_punctuation, str.title]

states_clean = []
for value in states:
    for function in clean_ops:
        value = function(value)
    states_clean.append(value)

print(states_clean)

# 2. 内建的map()函数可以将一个函数应用到一个序列上
for x in map(remove_punctuation, states):
    print(x)

# 3. 匿名函数（lambda表达式）
# 因为lambda函数与def声明的函数对象不同，并没有显式的__name__属性，所以也称为匿名函数
"""
def short_func(x):
    return x*2
二者等价
equiv_anon = lambda x:x*2
"""

# 4. 柯里化
# 柯里化是指通过部分参数应用的方式从已有函数中衍生出新的函数
def add_numbers(x, y):
    return x+y

def add_five(y): return add_numbers(5, y)  # 这就是“柯里化”应用
# 内建的functools模块可以使用partial函数简化上述处理
# from functools import partial
add_five = partial(add_numbers, 5)
