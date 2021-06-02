# google sheet自己的api对用户并不友好，这里使用第三方模块ezsheets
# pip install ezsheets

"""
google的说明文档：https://developers.google.com/sheets/api/quickstart/python
需要先启用Google Sheets API与Google Drive API：https://console.cloud.google.com/apis/dashboard
然后创建凭据，下载，重命名为credentials-sheets.json并放在脚本相同的目录下
"""

import ezsheets

ss = ezsheets.Spreadsheet('1p1hEzDWAHGkSyXoEtA7Ti9wkaBFpPBAGrjGPql0vtX0')
