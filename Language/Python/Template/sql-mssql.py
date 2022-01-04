# 使用pymssql连接ms sql server
# 很多人推荐使用pyodbc，这里没有尝试（貌似pyodbc确实比pymssql优秀）
# https://docs.microsoft.com/en-us/sql/connect/python/python-driver-for-sql-server?view=sql-server-ver15
# https://github.com/mkleehammer/pyodbc/wiki/Connecting-to-SQL-Server-from-Windows
# https://github.com/pymssql/pymssql

# pip install pymssql

import pymssql as mssql
from getpass import getpass

# 获取信息
server = input("Enter Server: ")
user = input("Enter User: ")
password = getpass("Enter Password: ")

# 创建数据库连接
conn = mssql.connect(server, user, password, "tempdb")

# sql语句
# %s：字符型参数；%d：数值型参数
sql = "select [name] as db, suser_sname(owner_sid) as 'user', state_desc,  collation_name from sys.databases where owner_sid < %d"

# 使用cursor()方法获取操作游标
cursor = conn.cursor(as_dict=True)

try:
    cursor.execute(sql, 100)
    for row in cursor:
        print("db: %-10s user: %-6s state: %-10s collation: %s" %
              (row['db'], row['user'], row['state_desc'], row['collation_name']))
except:
    print("Error: unable to fetch data.")

# 关闭数据库连接
conn.close()
