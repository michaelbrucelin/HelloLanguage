import time
import datetime

# 1. time模块
time.time()    # 1622882763.1689885
time.sleep(1)  # 暂停1s

# 2. datetime模块
datetime.datetime.now()  # datetime.datetime(2021, 6, 5, 8, 48, 27, 486680)
dt = datetime.datetime(2019, 10, 21, 16, 29, 0)
dt.year, dt.month, dt.day      # (2019, 10, 21)
dt.hour, dt.minute, dt.second  # (16, 29, 0)

datetime.datetime.fromtimestamp(1000000)
# datetime.datetime(1970, 1, 12, 13, 46, 40)
datetime.datetime.fromtimestamp(time.time())
# datetime.datetime(2021, 6, 5, 8, 53, 15, 82566)

# 3. datetime模块的timedelta数据类型
# timedelta是一个“时段”，而不是一个“时刻”
delta = datetime.timedelta(days=11, hours=10, minutes=9, seconds=8)
delta.days, delta.seconds, delta.microseconds  # (11, 36548, 0)
delta.total_seconds()  # 986948.0
str(delta)             # '11 days, 10:09:08'

dt = datetime.datetime.now()
thousandDays = datetime.timedelta(days=1000)
dt               # datetime.datetime(2021, 6, 5, 9, 1, 9, 667628)
dt+thousandDays  # datetime.datetime(2024, 3, 1, 9, 1, 9, 667628)

# 4. datetime与string
oct21st = datetime.datetime(2019, 10, 21, 16, 29, 0)
oct21st.strftime('%Y/%m/%d %H:%M:%S')  # '2019/10/21 16:29:00'
oct21st.strftime('%I:%M %p')           # '04:29 PM'
oct21st.strftime("%B of '%y")          # "October of '19"

datetime.datetime.strptime('October 21, 2019', '%B %d, %Y')
# datetime.datetime(2019, 10, 21, 0, 0)
datetime.datetime.strptime('2019/10/21 16:29:00', '%Y/%m/%d %H:%M:%S')
# datetime.datetime(2019, 10, 21, 16, 29)
datetime.datetime.strptime("October of '19", "%B of '%y")
# datetime.datetime(2019, 10, 1, 0, 0)
