# 使用pandas读取excel中的数据

import pandas as pd

excelfile = '/root/GithubProjects/MyScripts/Python/pandas/pandas_10rows.xlsx'
excelsheet = 'Sheet1'

xl_file = pd.ExcelFile(excelfile)          # 创建Excel对象
df = xl_file.parse(excelsheet)             # 将工作表(Sheet)转换成DataFrame
data = df.head()                           # 默认读取前5行的数据
print("获取到所有的值:\n{0}".format(data))  # 格式化输出

# 也可以直接这样读取指定excel的指定sheet
print("\n")
df = pd.read_excel(excelfile, sheet_name=excelsheet)
data = df.head()
print("获取到所有的值:\n{0}".format(data))

'''
df = pd.read_excel(excelfile)                                    # 直接默认读取到这个Excel的第一个表单
df = pd.read_excel(excelfile, sheet_name='student')              # 通过sheet_name来指定读取的表单
df = pd.read_excel(excelfile, sheet_name=['python', 'student'])  # 通过表单名同时指定多个
df = pd.read_excel(excelfile, sheet_name=0)                      # 通过表单索引来指定读取的表单
df = pd.read_excel(excelfile, sheet_name=['python', 1])          # 混合的方式来指定
df = pd.read_excel(excelfile, sheet_name=[1, 2])                 # 通过索引 同时指定多个
'''
