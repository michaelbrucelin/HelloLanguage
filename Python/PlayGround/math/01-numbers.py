from fractions import Fraction

# 1. 分数
# from fractions import Fraction
f = Fraction(3, 4)

# 2. 复数
a = 2 + 3j  # 复数的表示方法
type(a)  # complex
a.real  # 2.0
a.imag  # 3.0

b = complex(3, 4)  # 复数的另一种表示方法
b.conjugate()  # 求复数的共轭复数，(3-4j)
abs(b)  # 求复数的模，5.0
