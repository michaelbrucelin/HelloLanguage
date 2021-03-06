# function

def printinfo():
    print("---------------------------")
    print("    人生苦短，我用python    ")
    print("---------------------------")
# printinfo()


def add1(a, b):
    print(a + b)
# add1(10, 20)


def add2(a, b):
    return a + b
# print(add2(100, 200))


def divid(a, b):
    shang = a//b
    yushu = a % b
    return shang, yushu
# sh, yu = divid(10, 3)
# print("商: %d, 余数: %d" % (sh, yu))


def printline(n):
    print("-"*n)
# printline(100)


def printlines(m, n):
    for i in range(m):
        printline(n)
# printlines(10, 100)


# 局部变量与全局变量
arg0 = 100


def test01():
    arg0 = 200
    print("test01: %d" % arg0)


def test02():
    global arg0
    print("test02: %d" % arg0)
# test01()
# print("out: %d" % arg0)
# test02()
# print("out: %d" % arg0)


# 可变参数，类似于C#的params数组
# 形参*args，使用*作为前缀，python会创建一个空元祖，接收所有传入的实参
def variable_args(*args):
    print(args)
    for arg in args:
        print(arg)

# 形参**kwargs，使用**作为前缀，python会创建一个空字典，接收所有传入的键值对实参
def variable_kwvrgs(**kwargs):
    for key, value in kwargs.items():
        print(f"key:{key}, value:{value}")
