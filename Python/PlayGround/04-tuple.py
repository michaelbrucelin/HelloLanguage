# 元组

# 1. python中元组可以包含不同数据类型的元素
rhyme = (1, 2, 3, 4, 5, "上山打老虎")  # python中元素使用小括号表示
rhyme = 1, 2, 3, 4, 5, "上山打老虎"    # 也可以不使用小括号
print("rhyme:", rhyme)
for each in rhyme:
    print(each)

# 2. 元组是不可更改的，具有不可变性
# urhyme[1] = 10  # 这样会报错

# 3. python中的序列都支持切片，当然元组也可以，从序列中取一个范围的值，而不是一个值，即为切片
print("元组的前3个元素，rhyme[:3]:", rhyme[:3])
print("元组的后3个元素，rhyme[3:]:", rhyme[3:])
print("元组第2-4个元素，rhyme[2:4]:", rhyme[2:4])
print("全部元组元素，rhyme[:]:", rhyme[:])
print("元组0-6个元素，跨度为2，rhyme[0:6:2]:", rhyme[0:6:2])
print("全部元组元素，跨度为2，rhyme[::2]:", rhyme[::2])
print("全部元组元素倒序，跨度为2，rhyme[::-2]:", rhyme[::-2])
print("全部元组元素倒序，rhyme[::-1]:", rhyme[::-1])
