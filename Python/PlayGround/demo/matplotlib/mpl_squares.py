import matplotlib.pyplot as plt

plt.rcParams['font.sans-serif'] = ['SimHei']  # 用来正常显示中文标签
plt.rcParams['font.serif'] = ['SimHei']  # 用来正常显示中文标签
plt.rcParams['axes.unicode_minus'] = False  # 用来正常显示负号

squares = [1, 4, 9, 16, 25]
fig, ax = plt.subplots()  # subplots()可在一张图片中绘制一个或多个图表；fig表示整张图片，ax表示图片中的各个图表
ax.plot(squares, linewidth=3)  # plot()方法根据给定的数据以有意义的方式绘制图表

# 设置图表标题并给坐标轴加上标签
ax.set_title("平方数", fontsize=24)
ax.set_xlabel("值", fontsize=14)
ax.set_ylabel("值的平方", fontsize=14)

# 设置刻度标记的大小
ax.tick_params(axis='both', labelsize=14)

plt.show()  # 打开Matplotlib查看器并显示绘制的图表
