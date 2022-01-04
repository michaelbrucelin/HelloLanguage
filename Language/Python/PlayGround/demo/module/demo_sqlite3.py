import sqlite3

#连接/创建数据库
conn = sqlite3.connect("test.db")  #如果数据库文件不存在，会自动创建一个空的数据库

#创建表
conn = sqlite3.connect("test.db")
c = conn.cursor()
sql = '''
    create table company(
        id integer not null primary key autoincrement,
        name text not null,
        age int not null,
        address char(50),
        salary real
    )
'''
c.execute(sql)
conn.commit()
conn.close()

print("表创建成功")

#插入数据
conn = sqlite3.connect("test.db")
c = conn.cursor()
sql = "insert into company(name, age, address, salary) values('张三', 32, '北京', 8000)"
c.execute(sql)
sql = "insert into company(name, age, address, salary) values('李四', 33, '上海', 8800)"
c.execute(sql)
conn.commit()
conn.close()

print("插入成功")


#查询数据
conn = sqlite3.connect("test.db")
c = conn.cursor()
sql = "select id, name, age, address, salary from company"
cursor = c.execute(sql)
for row in cursor:
    print("id = ", row[0])
    print("name = ", row[1])
    print("age = ", row[2])
    print("address = ", row[3])
    print("salary = ", row[4], "\n")
conn.close()

print("查询成功")