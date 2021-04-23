# 使用pandas读取excel某个sheet并转为字典
# 逐行遍历示例

import pandas as pd

excelfile = '/root/GithubProjects/MyScripts/Python/pandas/pandas_10rows.xlsx'
excelsheet = 'Sheet1'

df = pd.read_excel(excelfile, sheet_name=excelsheet)

test_data = []
for i in df.index.values:  # 获取行索引进行遍历
    row_data = df.loc[i, ['CustomerID', 'TerritoryID', 'AccountNumber', 'CustomerType', 'rowguid', 'ModifiedDate']].to_dict()
    test_data.append(row_data)
print("最终获取到的数据是：\n{0}".format(test_data))
