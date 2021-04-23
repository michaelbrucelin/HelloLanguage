# excel中有一列为公司简介，统计所有公司简介中单词的词频

import sys
import pandas as pd

# excelfile = '/root/GithubProjects/MyScripts/Python/CompanyInfo_1000rows.xlsx'
# excelsheet = 'Sheet1'
excelfile = sys.argv[1]
sheet = sys.argv[2]
column = sys.argv[3]

df = pd.read_excel(excelfile, sheet_name=sheet)

# print(df[column].str.split(expand=True).stack().value_counts())

df[column].str.split(expand=True).stack().value_counts(
).to_excel(sys.argv[4], sys.argv[5])
