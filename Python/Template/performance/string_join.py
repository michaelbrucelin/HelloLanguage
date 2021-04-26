# 字符串拼接速度对比测试
"""
下面的测试数据，均来自与小甲鱼的结果，https://fishc.com.cn/thread-185429-1-1.html
而我亲自测试，python 3.7.3，二者基本没有差异，而且比小甲鱼的速度要快很多
"""

# test1 是使用加号（+）进行拼接
def test1(n):
    result = ""
    for i in range(n):
        result += "Python"
    return result

# test2 是使用字符串的join()方法进行拼接
def test2(n):
    str_list = []
    for i in range(n):
        str_list.append("Python")
    return "".join(str_list)

# 测试开始
import timeit  # 计时器

# 第一轮：1万个 "Python" 拼接
timeit.timeit("test1(10000)", setup="from __main__ import test1", number=1)  # 0.0012263000000984903
timeit.timeit("test2(10000)", setup="from __main__ import test2", number=1)  # 0.0009582000000136759

# 第二轮：10万个 "Python" 拼接
timeit.timeit("test1(100000)", setup="from __main__ import test1", number=1)  # 0.011719300000095245
timeit.timeit("test2(100000)", setup="from __main__ import test2", number=1)  # 0.006204399999887755

# 第三轮：100万个 "Python" 拼接
timeit.timeit("test1(1000000)", setup="from __main__ import test1", number=1)  # 1.2601186999997935
timeit.timeit("test2(1000000)", setup="from __main__ import test2", number=1)  # 0.08013690000007045

# 第四轮：1000万个 "Python" 拼接
timeit.timeit("test1(10000000)", setup="from __main__ import test1", number=1)  # 131.86178619999987
timeit.timeit("test2(10000000)", setup="from __main__ import test2", number=1)  # 0.8771347999995669

# 第五轮：1亿个 "Python" 拼接
timeit.timeit("test1(100000000)", setup="from __main__ import test1", number=1)  # 13738.4885822
timeit.timeit("test2(100000000)", setup="from __main__ import test2", number=1)  # 8.882412499999191
