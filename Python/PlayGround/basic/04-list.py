# 列表

import bisect

# 1. python中列表可以包含不同数据类型的元素
rhyme = [1, 2, 3, 4, 5, "上山打老虎"]
print("rhyme:", rhyme)
for each in rhyme:
    print(each)

# 2. -1索引对应的就是列表的最后一个元素
print("rhyme[-1]:", rhyme[-1])

# 3. 使用range()创建数字列表
nums = list(range(10))

# 4. 切片，从列表中取一个范围的值，而不是一个值，即为切片
# python中无论是range()，还是切片，语法都差不多，区间都是左闭右开
nums[2:4]    # [2, 3]                 列表第[2, 3)个元素
nums[:3]     # [0, 1, 2]              列表第[0, 3)个元素，即前3个元素，省略了起始索引，起始索引默认为0
nums[3:]     # [3, 4, 5, 6, 7, 8, 9]  列表第[3, end)个元素，省略了终止索引，终止索引默认为len(nums)
nums[:-3]    # [0, 1, 2, 3, 4, 5, 6]  列表第[0, end-3)个元素，即整个列表舍掉了最后3个元素
nums[-3:]    # [7, 8, 9]              列表第[end-3, end)个元素，即最后3个元素
nums[:]      # [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]  列表第[0, end)个元素，同时省略起始和终止索引，即全部列表元素
nums[0:6:2]  # [0, 2, 4]              列表第[0, 6)个元素，跨度为2
nums[::2]    # [0, 2, 4, 6, 8]        全部列表元素，跨度为2
nums[::-2]   # [9, 7, 5, 3, 1]        全部列表元素倒序，跨度为2
nums[::-1]   # [9, 8, 7, 6, 5, 4, 3, 2, 1, 0]  全部列表元素倒序

# 5. 在列表尾部追加元素
heros = ["钢铁侠", "绿巨人"]
heros.append("黑寡妇")
heros.extend(["鹰眼", "灭霸", "雷神"])
# 尽管可以直接使用 + 来给列表添加元素，但是效率比extend()低，因为 + 创建了新的列表对象，并且还要复制对象
# 下面两种方式第一种更快
list_of_lists = [[], [], [], []]
everything = []
for chunk in list_of_lists:
    everything.extend(chunk)         # 这样更快
everything = []
for chunk in list_of_lists:
    everything = everything + chunk  # 这样较慢

s = [1, 2, 3, 4, 5]
s[len(s):] = [6]
s[len(s):] = [7, 8, 9]

# 6. 在列表中间插入元素
s = [1, 2, 4, 5]
s.insert(2, 3)
s.insert(0, 0)       # 在列表头部插入元素
s.insert(len(s), 6)  # 在列表的尾部追加元素

# 7. 从列表中删除元素
heros.remove("灭霸")  # 如果列表中有多个匹配的元素，只删除第一个，如果列表中不存在匹配的元素，会报错
heros.pop(2)
del heros[2]
heros.clear()  # 清空列表

# 8. 更改列表中的元素
heros = ["蜘蛛侠", "绿巨人", "黑寡妇", "鹰眼", "灭霸", "雷神"]
heros[4] = "钢铁侠"
heros[heros.index("黑寡妇")] = "神奇女侠"
heros[3:] = ["林冲", "武松", "鲁智深"]

# 9. 列表排序
nums = [3, 1, 9, 6, 8, 3, 5, 3]
nums.sort()              # 永久排序，彻底的更改了nums列表
nums.sort(reverse=True)
sorted(nums)             # 临时排序，输出排序后的列表，原始列表没有变化
sorted(nums, reverse=True)
# 先正序，再反转也可以逆序排序，可惜不支持函数式编程
nums.sort()
nums.reverse()  # 永久更改，彻底的更改了nums列表
# bisect可以将元素插入到排序好的列表的合适位置，但是不会检查列表是否是排序后的
# bisect使用的二分法
# import bisect
nums = [1, 2, 3, 4, 5, 6, 7]
bisect.insort(nums, 6)

# 10. 列表的一些其他方法
nums = [3, 1, 9, 6, 8, 3, 5, 3]
nums.count(3)  # 列表中元素3的个数
nums.index(3)  # 列表中元素3的索引
nums.index(3, 1, 7)
3 in nums
3 not in nums
max(nums)
min(nums)
sum(nums)

s = [1, 2, 3]
t = [4, 5, 6]
print(s + t)  # 拼接两个列表
print(s * 3)  # 重复一个列表指定的次数
