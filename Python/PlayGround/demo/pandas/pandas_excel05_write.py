# 使用pandas将数据导出到excel

import sys
import pandas as pd

# 3. 将多份数据导出到同一个excel的不同sheet中
l1 = [1, 2, 3, 4]
l2 = [5, 6, 7, 8]
df1 = pd.DataFrame({'F1': l1, 'F2': l2})
df2 = pd.DataFrame([['a', 'b'], ['c', 'd']], index=['row01', 'row02'], columns=['col01', 'col02'])

with pd.ExcelWriter(sys.argv[1]) as writer:
    df1.to_excel(writer, sheet_name=sys.argv[2])
    df2.to_excel(writer, sheet_name=sys.argv[3])

# 向已有excel中追加一个sheet
df3 = pd.DataFrame([['A', 'B'], ['C', 'D']], index=['ROW01', 'ROW02'], columns=['COL01', 'COL02'])
with pd.ExcelWriter(sys.argv[1], mode='a') as writer:
    df3.to_excel(writer, sheet_name=sys.argv[4])