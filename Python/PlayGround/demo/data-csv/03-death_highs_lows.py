import csv
from datetime import datetime

import matplotlib.pyplot as plt

filename = 'data/death_valley_2018_simple.csv'
with open(filename) as f:
    reader = csv.reader(f)
    header_row = next(reader)
    # for index, column_header in enumerate(header_row):
    #     print(index, column_header)
    # 从文件中获取日期、最高温度和最低温度
    dates, highs, lows = [], [], []
    for row in reader:
        current_date = datetime.strptime(row[2], '%Y-%m-%d')
        try:
            high = int(row[4])
            low = int(row[5])
        except ValueError:
            print(f"Missing data for {current_date}")
        else:
            dates.append(current_date)
            highs.append(high)
            lows.append(low)

# 根据最高温度和最低温度绘制图形
plt.style.use('seaborn')
plt.rcParams['font.sans-serif'] = ['SimHei']  # 用来正常显示中文标签
plt.rcParams['font.serif'] = ['SimHei']  # 用来正常显示中文标签
plt.rcParams['axes.unicode_minus'] = False  # 用来正常显示负号

fig, ax = plt.subplots()
ax.plot(dates, highs, c='red', alpha=0.5)
ax.plot(dates, lows, c='blue', alpha=0.5)
ax.fill_between(dates, highs, lows, facecolor='blue', alpha=0.1)  # 绘制区域颜色

# 设置图形格式
title = "2018年每日最高温度和最低温度\n美国加利福尼亚州死亡谷"
ax.set_title(title, fontsize=20)
ax.set_xlabel('', fontsize=16)
fig.autofmt_xdate()  # 绘制倾斜的日期，免其彼此重叠
ax.set_ylabel("温度 (F)", fontsize=16)
ax.tick_params(axis='both', which='major', labelsize=16)

plt.show()
