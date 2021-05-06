# exception

# 1. 异常的写法，可以配合else
try:
    print(8/0)
except ZeroDivisionError:
    print("You can't divide by zero!")
else:
    print("success.")

# 2. 抛异常
'''
print("----- test 01 -----")
f = open("notexists.txt", "r")
print("----- test 02 -----")
'''

# 3. 使用pass忽略异常
try:
    print("----- test 01 -----")
    f = open("notexists.txt", "r")
    print("----- test 02 -----")
except IOError:
    pass

# 4. 其他异常用法
try:
    print("----- test 01 -----")
    f = open("notexists.txt", "r")
    print("----- test 02 -----")
    print(num)
    print("----- test 03 -----")
except (IOError, NameError) as result:
    print(result)

try:
    print("----- test 01 -----")
    f = open("notexists.txt", "r")
    print("----- test 02 -----")
    print(num)
    print("----- test 03 -----")
except Exception as result:
    print(result)

import time
try:
    f = open("notexists.txt", "r")
    try:
        while True:
            content = f.readline()
            if len(content) == 0:
                break
            time.sleep(2)
            print(content)
    finally:
        f.close()
        print("file close")
except Exception as result:
    print(result)
