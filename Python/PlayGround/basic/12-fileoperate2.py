# 利用shelve模块，可以操作二进制文件，有些类似于C#中的序列化

import shelve

# 1. 将数据写入二进制文件
# 下面代码在Linux上会创建12-testdata.db文件，而在Windows上会创建12-testdata.bak, 12-testdata.dat, 12-testdata.dir三个文件
cats = ['Zophie', 'Pooka', 'Simon']
shelfFile = shelve.open('12-testdata')
shelfFile['cats'] = cats
shelfFile.close()

# 2. 读取二进制文件
shelvFile = shelve.open('12-testdata')
type(shelfFile)           # shelve.DbfilenameShelf
list(shelvFile.keys())    # ['cats']
list(shelvFile.values())  # [['Zophie', 'Pooka', 'Simon']]
shelvFile['cats']         # ['Zophie', 'Pooka', 'Simon']
shelvFile.close()
