# 列表推导式（列表解析，列表表达式）
# 列表推导式不仅仅是语法糖，效率也比循环快很多
# 主要是因为循环使用的是python虚拟机pvm中以步进的方式执行的，而列表推导式在python的解释器中使用C执行

# 1. 将列表中每一项元素*2
x = [1, 2, 3, 4, 5]
x = [i*2 for i in x]
print(x)

# 2. 创建一个列表
x = [i+1 for i in range(10)]
print(x)

# 3. 另一个示例
x = [c*2 for c in "micha"]
print(x)
code = [ord(c) for c in "micha"]  # ord将字符转为Unicode编码
print(code)

# 4. 另一个示例
matrix = [[1, 2, 3],
          [4, 5, 6],
          [7, 8, 9]]
col2 = [row[1] for row in matrix]
print(col2)
diag = [matrix[i][i] for i in range(len(matrix))]  # 主对角线的值
print(diag)
diag2 = [matrix[i][-i-1] for i in range(len(matrix))]
print(diag2)

# 5. 创建一个嵌套列表
x = [[0]*3 for i in range(3)]
x[1][1] = 1
print(x)

# 6. 列表推导式的过滤条件
even = [i for i in range(10) if i % 2 == 0]
print(even)
even = [i+1 for i in range(10) if i % 2 == 0]  # 先执行if，再执行i+1
print(even)
words = ["Great", "Frank", "Brilliant", "Excellent", "Fantistic"]
fwords = [word for word in words if word.startswith('F')]
print(fwords)

# 7. 列表推导式的嵌套
matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
flatten = [col for row in matrix for col in row]
print(flatten)

# 8. 通过列表循环实现笛卡尔积
descartes = [x+y for x in "ABCD" for y in "1234"]
print(descartes)

# 9. 列表推导式的终极语法
z = [[x, y] for x in range(10) if x % 2 == 0 for y in range(10) if y % 3 == 0]
print(z)
