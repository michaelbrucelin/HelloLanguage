# 1. python中列表可以包含不同数据类型的元素
rhyme = [1, 2, 3, 4, 5, "上山打老虎"]
print("rhyme:", rhyme)
for each in rhyme:
    print(each)

# 2. -1索引对应的就是列表的最后一个元素
print("rhyme[-1]:", rhyme[-1])

# 3. 切片，从列表中取一个范围的值，而不是一个值，即为切片
print("列表的前3个元素，rhyme[:3]:", rhyme[:3])
print("列表的后3个元素，rhyme[3:]:", rhyme[3:])
print("列表第2-4个元素，rhyme[2:4]:", rhyme[2:4])
print("全部列表元素，rhyme[:]:", rhyme[:])
print("列表0-6个元素，跨度为2，rhyme[0:6:2]:", rhyme[0:6:2])
print("全部列表元素，跨度为2，rhyme[::2]:", rhyme[::2])
print("全部列表元素倒序，跨度为2，rhyme[::-2]:", rhyme[::-2])
print("全部列表元素倒序，rhyme[::-1]:", rhyme[::-1])