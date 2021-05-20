# 使用mysqlclient连接mysql
# https://github.com/PyMySQL/mysqlclient
# apt-get install python3-dev default-libmysqlclient-dev build-essential  # Debian / Ubuntu
# yum install python3-devel mysql-devel                                   # Red Hat / CentOS
# pip install mysqlclient

import MySQLdb as mysql
from getpass import getpass

# 获取信息
hostname = input("Enter Hostname: ")
account = input("Enter Account: ")
password = getpass("Enter Password: ")

# 打开数据库连接
db = mysql.connect(hostname, account, password, "mysql")

# 使用cursor()方法获取操作游标
cursor = db.cursor()

# sql语句
sql = "select host, user, plugin from mysql.user;"

try:
    # 执行sql语句
    cursor.execute(sql)
    # 获取所有记录列表
    results = cursor.fetchall()
    for row in results:
        host = row[0]
        user = row[1]
        pwd = row[2]
        print(f"host: {host:<15}user: {user:<20}\tpassword: {pwd}")
except:
    print("Error: unable to fetch data.")

# 关闭数据库连接
db.close()


# https://stackoverflow.com/questions/4960048/how-can-i-connect-to-mysql-in-python-3-on-windows
"""
There are currently a few options for using Python 3 with mysql:

1. https://pypi.python.org/pypi/mysql-connector-python
Officially supported by Oracle
Pure python
A little slow
Not compatible with MySQLdb

2. https://pypi.python.org/pypi/pymysql
Pure python
Faster than mysql-connector
Almost completely compatible with MySQLdb, after calling pymysql.install_as_MySQLdb()

3. https://pypi.python.org/pypi/cymysql
fork of pymysql with optional C speedups

4. https://pypi.python.org/pypi/mysqlclient
Django's recommended library.
Friendly fork of the original MySQLdb, hopes to merge back some day
The fastest implementation, as it is C based.
The most compatible with MySQLdb, as it is a fork
Debian and Ubuntu use it to provide both python-mysqldb andpython3-mysqldb packages.

benchmarks here: https://github.com/methane/mysql-driver-benchmarks
"""
