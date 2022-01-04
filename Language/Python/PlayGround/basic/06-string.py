# 字符串

# 1. 大小写相关
str = "I love China."
str.capitalize()  # 'I love china.'  将字符串的首字母转为大写，其余的小写
str.casefold()    # 'i love china.'  将字符串所有字母转为小写
str.title()       # 'I Love China.'  将字符串中每个单词的首字母转为大写，其余的小写
str.swapcase()    # 'i LOVE cHINA.'  将字符串中所有字母大小写翻转
str.upper()       # 'I LOVE CHINA.'  将字符串所有字母转为大写
str.lower()       # 'i love china.'  将字符串所有字母转为小写
# lower()只能处理英文字母，而casefold()除了英文还能处理其他语种的字母，例如德语与法语

# 2. 对齐相关
# 第一个参数是width，如果width小于等于字符串的长度，字符串原样输出
# 第二个参数是fillchar，默认值是空格
str = "我爱中国"
str.center(10)  # '   我爱中国   '
str.ljust(10)   # '我爱中国      '
str.rjust(10)   # '      我爱中国'
str.zfill(10)   # '000000我爱中国'
str.center(10, "=")  # '===我爱中国==='
str.ljust(10, "=")   # '我爱中国======'
str.rjust(10, "=")   # '======我爱中国'

# 3. 查找相关
str = "上海自来水来自海上"
str.count("海")   # 2  查找子串的数量
str.find("海")    # 1  查找子串的索引，子串不存在结果为-1
str.rfind("海")   # 7  查找子串的索引，从右向左查找，子串不存在结果为-1
str.index("海")   # 1  查找子串的索引，子串不存在抛异常
str.rindex("海")  # 7  查找子串的索引，从右向左查找，子串不存在抛异常
# 其中每个参数还可以指定第二个和第三个参数，表示在原字符串中的查找范围

# 4. 替换
str = """
    print("hello world.")  # 我的vscode配置了使用tab替换空格，假定这行前面是tab，而不是空格
    print("hello u.")
"""
str.expandtabs(4)  # 将tab替换为4个空格，默认为8个空格

str = "ABCDABCDABCDABCD"
str.replace("A", "甲")     # '甲BCD甲BCD甲BCD甲BCD'
str.replace("A", "甲", 2)  # '甲BCD甲BCDABCDABCD'

str = "I love China."
table = str.maketrans("ABCDEFG", "1234567")
str.translate(table)  # 'I love 3hina.'  类似于字典翻译

table = str.maketrans("ABCDEFG", "1234567", "love")
str.translate(table)  # 'I  3hina.'  字典的第三个参数表示忽略掉的字符串

# 5. 判断
str = "I love Python."
str.startswith("I")
str.startswith("love", 2, len(str))  # str.startswith("love", 2)
str.startswith(("She", "He", "You", "I"))
str.endswith("on.")  # str.endswith("love", 0, 5)

str = "I love Python."
str.istitle()       # False  "I Love Python." True
str.isupper()       # False
str.islower()       # True
str.isalpha()       # 判断是否全部为字母
str.isspace()       # 判断是否是空白字符串，空格、tab、换行等不可见字符均为空白字符
str.isprintable()   # 判断字符串字符是否全部为可打印字符，可以理解为可见字符
str.isalnum()       # 相当于isalpha() || isdigit() || isdecimal() || isnumeric()
str.isidentifier()  # 检查字符串是否为一个合法的Python标识符

# 数字判断
num = "12345"
num.isdecimal()  # True
num.isdigit()    # True
num.isnumeric()  # True
num = "2²"
num.isdecimal()  # False
num.isdigit()    # True
num.isnumeric()  # True
num = "ⅠⅡⅢⅣⅤ"
num.isdecimal()  # False
num.isdigit()    # False
num.isnumeric()  # True
num = "一二三四五"
num.isdecimal()  # False
num.isdigit()    # False
num.isnumeric()  # True
num = "壹贰叁肆伍"
num.isdecimal()  # False
num.isdigit()    # False
num.isnumeric()  # True
num = "ⅠⅡ三四伍"
num.isdecimal()  # False
num.isdigit()    # False
num.isnumeric()  # True
