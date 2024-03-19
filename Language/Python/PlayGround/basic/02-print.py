# print()

# 1. 两个格式化方式
name1 = "mlin"
country1 = "CN"
age1 = 10
print("this is the var: ", age1)
# 格式化字符串的两种方式：
print("格式化字符串的两种方式：")
print("my name is %s, I am from %s, I am %d age now." %(name1, country1, age1))
print("my name is {0}, I am from {1}, I am {2} age now.".format(name1, country1, age1))

# 2. 其他设定
s1 = "www"
s2 = "baidu"
s3 = "com"
print(s1, s2, s3)
print(s1, s2, s3, sep=".")

print("hello", end=" ")
print("world", end="\t")
print("python", end="\n")
print("end")

# 3. 接收用户输入
password = input("please input your password: ")
print("your input: ", password)
print(type(password))  # <class 'str'>
