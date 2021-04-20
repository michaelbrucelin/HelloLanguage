tup1 = ()
tup2 = (1024)  # 当元组中只有一个元素时，后面必须加一个逗号，否则会被当成整形，而括号被解释为改变运算优先级的括号
tup3 = ("abc")
tup4 = (1024,)
print(type(tup1))
print(type(tup2))
print(type(tup3))
print(type(tup4))

tup5 = (000, 111, 222, 333, 444, 555, 666, 777, 888, 999)
print(tup5[0])
print(tup5[-1])
print(tup5[1:5])  #左闭右开
print(tup5[:4])
print(tup5[4:])