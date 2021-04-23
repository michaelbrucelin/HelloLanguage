# 使用pandas读取excel某个sheet中的行和列

import pandas as pd

excelfile = '/root/GithubProjects/MyScripts/Python/pandas/pandas_10rows.xlsx'
excelsheet = 'Sheet1'

df = pd.read_excel(excelfile, sheet_name=excelsheet)

# 1. 读取指定的单行，数据会存在列表里面
data = df.iloc[0].values       # 0表示数据的第1行（不含表头，即物理的第2行）
print("\n读取指定单行的数据：\n", format(data))

# 2. 读取指定的多行，数据会存在嵌套的列表里面
data = df.iloc[[1, 2]].values  # 读取指定多行的话，在iloc[]里面嵌套列表指定行数
print("\n读取指定多行的数据：\n", format(data))

# 3. 读取指定的单元格
data = df.iloc[1, 2]           # 读取第1行第2列的值，这里不需要嵌套列表
print("\n读取指定单元格的数据：\n", format(data))

# 4. 读取指定的多行多列值（注意不是Range，Range是4个单元格定义的一个二维数组，而这个就是指定行和列的交叉的单元格的值）
# 读取第1行第2行的AccountNumber以及ModifiedDate列的值，这里需要嵌套列表
data = df.loc[[1, 2], ['AccountNumber', 'ModifiedDate']].values
# data = df.iloc[[1, 2], [0, 3]].values
print("\n读取指定多行多列的数据：\n", format(data))

# 5. 获取所有行的指定列
data = df.loc[:, ['AccountNumber', 'ModifiedDate']].values
# data = df.iloc[:, [0, 3]].values
print("\n读取指定列的数据：\n", format(data))

# 6. 获取行号并打印输出
print("\n输出行号列表：\n", df.index.values)

# 7. 获取列名并打印输出
print("\n输出列标题（表头）：\n", df.columns.values)

# 8. 获取指定行数的值
print("\n输出指定行数的值：\n", df.sample(3).values)  # 这个方法类似于head()方法以及df.values方法

# 9. 获取指定列的值
print("\n输出指定列的值：\n", df['AccountNumber'].values)
