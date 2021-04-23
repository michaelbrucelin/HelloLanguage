# 使用pandas将数据导出到excel

import sys
import pandas as pd

l1 = [1, 2, 3, 4]
l2 = [5, 6, 7, 8]

# 1. 将数据导出到指定的sheet中
df = pd.DataFrame({'F1': l1, 'F2': l2})
'''
print(df)
    F1    F2
0    1     5
1    2     6
2    3     7
3    4     8
'''
df.to_excel(sys.argv[1], sheet_name=sys.argv[2], index=False)

# 2. 将数据导出到指定的sheet中
df = pd.DataFrame([['a', 'b'], ['c', 'd']], index=['row01', 'row02'], columns=['col01', 'col02'])
df.to_excel(sys.argv[1], sheet_name=sys.argv[2])
