# 测试一下脚本执行与编译执行的时间

dic, lst, i = {}, [], 0
for i in range(0, 10**7):
    dic[i] = 'A'*1024
    if i%1000 == 0:
        j = 0
        for j in range(0, 1024):
            lst.append(i*j)

"""
# time python3 compile.py
real    0m6.841s
user    0m6.227s
sys     0m0.612s

# python -m py_compile compile.py
# time python3 __pycache__/compile.cpython-39.pyc
real    0m6.256s
user    0m5.662s
sys     0m0.594s

# python -O -m py_compile compile.py
# time python3 __pycache__/compile.cpython-39.opt-1.pyc
real    0m6.179s
user    0m5.525s
sys     0m0.654s

# python3 -m pip install pyinstaller
# pyinstaller compile.py
# time dist/compile/compile  # 耗时反而更高了，不确认是操作的有问题，还是什么其他原因
real    0m7.339s
user    0m6.804s
sys     0m0.534s
"""
