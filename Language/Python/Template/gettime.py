# python中获取当前时间的字符串

'{0:%Y-%m-%d %H:%M:%S}'.format(datetime.datetime.now())
'{0:%Y%m%d_%H%M%S}'.format(datetime.datetime.now())      # 可以用做文件名
