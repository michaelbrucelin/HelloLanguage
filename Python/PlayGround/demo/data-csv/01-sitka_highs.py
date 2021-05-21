import csv
from datetime import datetime

import matplotlib.pyplot as plt

filename = 'data/sitka_weather_2018_simple.csv'
with open(filename) as f:
    reader = csv.reader(f)
    header_row = next(reader)
    # for index, column_header in enumerate(header_row):
    #     print(index, column_header)
    # 从文件中获取日期和最高温度
    dates, highs = [], []
    for row in reader:
        current_date = datetime.strptime(row[2], '%Y-%m-%d')
        high = int(row[5])
        dates.append(current_date)
        highs.append(high)

# 根据最高温度绘制图形
plt.style.use('seaborn')
plt.rcParams['font.sans-serif'] = ['SimHei']  # 用来正常显示中文标签
plt.rcParams['font.serif'] = ['SimHei']  # 用来正常显示中文标签
plt.rcParams['axes.unicode_minus'] = False  # 用来正常显示负号

fig, ax = plt.subplots()
ax.plot(dates, highs, c='red')

# 设置图形格式
ax.set_title("2018年每日最高温度", fontsize=24)
ax.set_xlabel('', fontsize=16)
fig.autofmt_xdate()  # 绘制倾斜的日期，免其彼此重叠
ax.set_ylabel("温度 (F)", fontsize=16)
ax.tick_params(axis='both', which='major', labelsize=16)

plt.show()
