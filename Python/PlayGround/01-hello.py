# 1. 打印内置函数
import fractions
import decimal
import random
print(dir(__builtins__))  # 在IDLE中可以执行，不确认为什么在脚本中提示错误，但是可执行

# 2. 多重赋值与交换变量的值
x, y = 3, 5  # 其实先将 3, 5 打包为元组，然后将元组赋值给前面的变量

x = 3
y = 5
x, y = y, x
print(x, y)

# 3. r表示输出原始字符串，相当于C#中的@
print(r"C:\three\two\one\zero\now:", "C:\three\two\one\zero\now")
print(r"C:\\three\\two\\one\\zero\\now:", "C:\\three\\two\\one\\zero\\now")
print(r'r"C:\three\two\one\zero\now"', r"C:\three\two\one\zero\now")

# 4. 多行字符串
poetry1 = """
从明天起，做一个幸福的人
喂马，劈柴，周游世界
从明天起，关心粮食和蔬菜
我有一所房子，面朝大海，春暖花开

从明天起，和每一个亲人通信
告诉他们我的幸福
那幸福的闪电告诉我的
我将告诉每一个人
"""
poetry2 = '''
给每一条河每一座山取一个温暖的名字
陌生人，我也为你祝福
愿你有一个灿烂的前程
愿你有情人终成眷属
愿你在尘世获得幸福
我只愿面朝大海，春暖花开
'''

print(poetry1, poetry2)

# 5. 重复字符串
print("Hello * 3:", "Hello" * 3)

# 6. 随机数
print("random.randint(1, 100):", random.randint(1, 100))

# 7. 记录伪随机数的状态（种子），实现伪随机攻击
seed = random.getstate()
print("第一次随机")
i = 3
while i > 0:
    print(random.randint(1, 100))
    i = i - 1
print("第二次随机")
random.setstate(seed)
i = 3
while i > 0:
    print(random.randint(1, 100))
    i = i - 1

# 8. 精确的数字需要使用decimal
a = 0.1
b = 0.2
print("%s + %s =" % (a, b), a + b)

a = decimal.Decimal('0.1')
b = decimal.Decimal('0.2')
print("decimal %s + %s=" % (a, b), a + b)

# 9. 复数
x = 1 + 2j
print(x.real)
print(x.imag)

# 10. 有理数（分数）
x = fractions.Fraction(2, 3)
print("Fraction(2, 3):", x)

# 11. 逻辑运算符的短路行为
print("3 and 4:", 3 and 4)
print("3 or 4:", 3 or 4)
print('"mlin" and "micha":', "mlin" and "micha")
print('"mlin" or "micha":', "mlin" or "micha")
print("(not 1) or (0 and 1) or (3 and 4) or (5 and 6) or (7 and 8 and 9):",
      (not 1) or (0 and 1) or (3 and 4) or (5 and 6) or (7 and 8 and 9))

# 12. 一行语句想要换行，除了使用 \ 之外，还可以用 () 括起来

# 13. 临时变量 _
_ = 1024
print(_)

# 14. 检查是否为Python的保留字或合法标识符
"if".isidentifier()      # 检查是否为合法的Python标识符
import keyword
keyword.iskeyword("if")  # 检查是否为Python的保留字
