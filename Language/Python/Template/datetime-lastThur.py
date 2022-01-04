# 如果今天是周四，就返回今天的日期，如果今天不是周四，就往前找，找到最近的周四并返回

import datetime


def get_last_thursday(cur_time=datetime.datetime.now()):
    # cur_time = datetime.datetime.now()
    cur_week = cur_time.isoweekday()
    return cur_time - datetime.timedelta(days=(cur_week+3) % 7)


cur_time = datetime.datetime.now()
print(get_last_thursday())
print(get_last_thursday(cur_time + datetime.timedelta(days=1)))
print(get_last_thursday(cur_time + datetime.timedelta(days=2)))
print(get_last_thursday(cur_time + datetime.timedelta(days=3)))
print(get_last_thursday(cur_time + datetime.timedelta(days=4)))
print(get_last_thursday(cur_time + datetime.timedelta(days=5)))
print(get_last_thursday(cur_time + datetime.timedelta(days=6)))
print(get_last_thursday(cur_time + datetime.timedelta(days=7)))
print(get_last_thursday(cur_time + datetime.timedelta(days=8)))
print(get_last_thursday(cur_time + datetime.timedelta(days=9)))
