# 1. 截取
import pyperclip
str = "    www.google.com    "
str.lstrip()         # 'www.google.com    '
str.rstrip()         # '    www.google.com'
str.strip()          # 'www.google.com'
str = "www.google.com"
str.lstrip("wcom.")  # 'google.com'
str.rstrip("wcom.")  # 'www.google'
str.strip("wcom.")   # 'google'
str = "www.google.com"
str.removeprefix("www.")  # 'google.com'  据说python3.9才支持，当前环境为3.7.3，不支持
str.removesuffix(".com")  # 'www.google'  据说python3.9才支持，当前环境为3.7.3，不支持

# 2. 拆分与拼接
str = "苟日新，日日新，又日新"
str.partition("，")   # ('苟日新', '，', '日日新，又日新')
str.rpartition("，")  # ('苟日新，日日新', '，', '又日新')
str.split("，")       # ['苟日新', '日日新', '又日新']
str.rsplit("，")      # ['苟日新', '日日新', '又日新']
str.split("，", 1)    # ['苟日新', '日日新，又日新']
str.rsplit("，", 1)   # ['苟日新，日日新', '又日新']
str = "按行分割\nLinux\rOSX\r\nWindows"
str.splitlines()      # ['按行分割', 'Linux', 'OSX', 'Windows']
str.splitlines(True)  # ['按行分割\n', 'Linux\r', 'OSX\r\n', 'Windows']

splitor = ","
items = ["甲", "乙", "丙", "丁"]
splitor.join(items)  # '甲,乙,丙,丁'
"".join(items)       # '甲乙丙丁'
# join拼接字符串的效率要高于使用 + 拼接字符串，估计与C#中的 $"{var1}...{var2}" (StringBuilder)道理差不多，具体没查阅

# 3. 另一种字符串拆分
str = "hello, world!"
str.partition('w')      # ('hello, ', 'w', 'orld!')
str.partition('world')  # ('hello, ', 'world', '!')
str.partition('o')      # ('hell', 'o', ', world!')
str.partition('xyz')    # ('hello, world!', '', '')

# 4. 字符编码相关(Unicode)
ord('A')    # 65
ord('我')   # 25105
chr(65)     # 'A'
chr(25105)  # '我'

# 5. 使用剪切板
# import pyperclip
pyperclip.copy("hello world.")  # 复制文本到剪切板
pyperclip.paste()               # 使用剪切板中的文本
