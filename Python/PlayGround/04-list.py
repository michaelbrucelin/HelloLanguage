# 列表

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

# 4. 在列表尾部追加元素
heros = ["钢铁侠", "绿巨人"]
heros.append("黑寡妇")
heros.extend(["鹰眼", "灭霸", "雷神"])

s = [1, 2, 3, 4, 5]
s[len(s):] = [6]
s[len(s):] = [7, 8, 9]

# 5. 在列表中间插入元素
s = [1, 2, 4, 5]
s.insert(2, 3)
s.insert(0, 0)       # 在列表头部插入元素
s.insert(len(s), 6)  # 在列表的尾部追加元素

# 6. 从列表中删除元素
heros.remove("灭霸")  # 如果列表中有多个匹配的元素，只删除第一个，如果列表中不存在匹配的元素，会报错
heros.pop(2)
del heros[2]
heros.clear()  # 清空列表

# 7. 更改列表中的元素
heros = ["蜘蛛侠", "绿巨人", "黑寡妇", "鹰眼", "灭霸", "雷神"]
heros[4] = "钢铁侠"
heros[heros.index("黑寡妇")] = "神奇女侠"
heros[3:] = ["林冲", "武松", "鲁智深"]

# 8. 列表排序
nums = [3, 1, 9, 6, 8, 3, 5, 3]
nums.sort()              # 永久排序，彻底的更改了nums列表
nums.sort(reverse=True)
sorted(nums)             # 临时排序，输出排序后的列表，原始列表没有变化
sorted(nums, reverse=True)
# 先正序，再反转也可以逆序排序，可惜不支持函数式编程
nums.sort()
nums.reverse()  # 永久更改，彻底的更改了nums列表

# 9. 列表的一些其他方法
nums.count(3)  # 列表中元素3的个数
nums.index(3)  # 列表中元素3的索引
nums.index(3, 1, 7)

s = [1, 2, 3]
t = [4, 5, 6]
print(s + t)  # 拼接两个列表
print(s * 3)  # 重复一个列表指定的次数

# 10. 浅拷贝
nums_copy1 = nums.copy()
nums_copy2 = nums[:]

# 11. 嵌套列表，二(n)维列表
matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
matrix = [[1, 2, 3],
          [4, 5, 6],
          [7, 8, 9]]

print(matrix[1][1])

for i in matrix:
    for j in i:
        print(j, end=' ')
    print()
