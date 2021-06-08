import numpy as np

# 1. numpy的算法库是用C写的，所以通常占用内存更少，运行更快
my_arr = np.arange(1000000)
my_list = list(range(1000000))

%time for _ in range(10): my_arr = my_arr * 2
# CPU times: user 22.9 ms, sys: 4.27 ms, total: 27.2 ms
# Wall time: 38.9 ms

%time for _ in range(10): my_list = [x*2 for x in my_list]
# CPU times: user 839 ms, sys: 221 ms, total: 1.06 s
# Wall time: 1.06 s
