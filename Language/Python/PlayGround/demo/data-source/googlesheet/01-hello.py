# google sheet自己的api对用户并不友好，这里使用第三方模块ezsheets
# pip install ezsheets

"""
google的说明文档：https://developers.google.com/sheets/api/quickstart/python
需要先启用Google Sheets API与Google Drive API：https://console.cloud.google.com/apis/dashboard
然后创建凭据，下载，重命名为credentials-sheets.json并放在脚本相同的目录下
"""

import ezsheets

# 1. 获取google sheets
ss = ezsheets.Spreadsheet('1p1hEzDWAHGkSyXoEtA7Ti9wkaBFpPBAGrjGPql0vtX0')
ss  # Spreadsheet(spreadsheetId='1p1hEzDWAHGkSyXoEtA7Ti9wkaBFpPBAGrjGPql0vtX0')
ss.title  # '工作表1'

ezsheets.listSpreadsheets()  # 列出当前google账户中的电子表格

# 2. 创建与删除google sheets
ss = ezsheets.createSpreadsheet('Titile of My New Spreadsheet')
ss.title  # 'Titile of My New Spreadsheet'

ss.delete()                # 将电子表格移到google drive的trash文件夹中
ss.delete(permanent=True)  # 永久删除电子表格

# 3. 电子表格的一些属性
ss = ezsheets.Spreadsheet('1p1hEzDWAHGkSyXoEtA7Ti9wkaBFpPBAGrjGPql0vtX0')
ss.title                 # spreadsheet的title
ss.title = "Class Data"  # 更改spreadsheet的title
ss.spreadsheetId         # 表格的UID，只读属性
ss.url                   # 表格的链接，只读属性
ss.sheetTitles           # 所有sheet的title
ss.sheets                # 所有的sheet
ss[0]                    # 第一个sheet
ss['Students']           # 通过title指定某个sheet
del ss[0]                # 删除第一个sheet
ss.refresh()             # 刷新

sheet = ss.sheets[0]
sheet.rowCount         # 表格的行数
sheet.columnCount      # 表格的列数
sheet.rowCount = 2     # 更改行数，相当于删除数据，将第三行（含）以后的数据删除
sheet.columnCount = 2  # 更改列数，相当于删除数据，将第三列（含）以后的数据删除

# 4. 上传和下载电子表格
# 将现有的Excel，OpenOffice，CSV或TSV电子表格上传到google sheets
ss = ezsheets.upload('xxxx.xlsx')

ss = ezsheets.Spreadsheet('1p1hEzDWAHGkSyXoEtA7Ti9wkaBFpPBAGrjGPql0vtX0')
ss.downloadAsExcel()
ss.downloadAsODS()    # OpenOffice文件
ss.downloadAsCSV()
ss.downloadAsTSV()
ss.downloadAsPDF()
ss.downloadAsHTML()   # 以.zip的形式下载

# 5. 读写数据
ss = ezsheets.createSpreadsheet('My Spreadsheet')
sheet = ss[0]
sheet['A1'] = 'Name'
sheet['B1'] = 'Age'
sheet['C1'] = 'Favorite Moive'
sheet['A1']   # Name
sheet[2, 1]   # Age 注意这里第一个索引是列，第二个索引才是行

ss.createSheet('New Sheet1')  # 创建一个新的sheet
ss.createSheet('New Sheet2')  # 创建一个新的sheet
ss['New Sheet1'].delete()
ss[0].delete()

ss[0].clear()  # 清空第一个sheet的全部cell

# 当有大量数据需要操作，逐个单元格操作会很慢（每次操作都要联网），这时可以采用整行（列）操作
sheet.getRow(1)                                      # 获取一行
sheet.getColumn(1)                                   # 获取一列
sheet.getColumn('A')                                 # 获取一列
sheet.updateRow(2, ['XXX', '123', '1.23'])           # 更新一行
sheet.updateColumn(2, ['AAA', 'BBB', 'CCC', 'DDD'])  # 更新一列

rows = sheet.getRows()  # 获取整个sheet的数据
rows[1][0] = 'ABCD'     # 本地更改数据
sheet.updateRows(rows)  # 整表更新，这样操作最快

sheet.refresh()

# 6. 行列地址的转换
ezsheets.convertAddress('A2')      # (1, 2)
ezsheets.convertAddress(1, 2)      # A2
ezsheets.getColumnLetterOf(2)      # B
ezsheets.getColumnNumberOf('B')    # 2
ezsheets.getColumnLetterOf(999)    # ALK
ezsheets.getColumnNumberOf('ZZZ')  # 18278

# 7. 复制工作表
ss1 = ezsheets.createSpreadsheet('First Spreadsheet')
ss2 = ezsheets.createSpreadsheet('Second Spreadsheet')
ss1[0].copyTo(ss2)  # 将ss1中的第一个sheet复制到ss2中
